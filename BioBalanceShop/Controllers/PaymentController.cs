using BioBalanceShop.Attributes;
using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Exceptions;
using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Core.Models.Payment;
using BioBalanceShop.Core.Models.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Security.Claims;
using static BioBalanceShop.Core.Constants.CookieConstants;
using static BioBalanceShop.Infrastructure.Constants.ConfigurationConstants;
using static BioBalanceShop.Core.Constants.ExceptionErrorMessages;

namespace BioBalanceShop.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        private readonly IPaymentService _paymentService;
        private readonly ICartService _cartService;
        private readonly ICookieService _cookieService;
        private readonly IOrderService _orderService;
        private readonly ILogger _logger;

        public PaymentController(
            IConfiguration configuration,
            IProductService productService,
            IShopService shopService,
            IPaymentService paymentService,
            ICartService cartService,
            ICookieService cookieService,
            IOrderService orderService,
            ILogger<CartController> logger)
        {
            _configuration = configuration;
            _productService = productService;
            _shopService = shopService;
            _paymentService = paymentService;
            _cartService = cartService;
            _cookieService = cookieService;
            _orderService = orderService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        [RequiresCookieConsent]
        public async Task<IActionResult> Charge()
        {
            try
            {
                var publishableKey = _configuration[StripeSettings.PublishableKey];
                ViewBag.PublishableKey = publishableKey;

                var model = _cookieService.GetOrderInfoFromCookie(Request.Cookies[OrderInfoCookie]);

                var currency = await _shopService.GetShopCurrency();
                model.Order.Currency = new ShopCurrencyServiceModel()
                {
                    Id = currency.Id,
                    CurrencyCode = currency.CurrencyCode,
                    CurrencyIsSymbolPrefix = currency.CurrencyIsSymbolPrefix,
                    CurrencySymbol = currency.CurrencySymbol
                };

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PaymentConroller/Charge/Get");
                throw new InternalServerErrorException(InternalServerErrorMessage);
            }

        }

        [IgnoreAntiforgeryToken]
        [AllowAnonymous]
        [HttpPost]
        [RequiresCookieConsent]
        public async Task<IActionResult> Charge(string stripeToken)
        {
            if (string.IsNullOrEmpty(stripeToken))
            {
                return BadRequest();
            }

            try
            {
                var cart = _cookieService.GetOrCreateCartCookie(Request.Cookies[ShoppingCartCookie]);
                CartIndexModel productsInCart = await _cartService.GetCartProductsInfo(cart);

                foreach (var item in productsInCart.Items)
                {
                    if (!await _productService.ExistsAsync(item.ProductId))
                    {
                        _logger.LogError($"{item.Title} could not be found: PaymentController/Charge/Post");
                        throw new PaymentErrorException($"An error occurred while processing your order. {item.Title} could not be found. Please update your cart and try again.");
                    }

                    if (item.QuantityToOrder > item.QuantityInStock)
                    {
                        _logger.LogError($"{item.Title} out of stock: PaymentController/Charge/Post");
                        throw new PaymentErrorException($"An error occurred while processing your order. {item.Title} is no longer available. Please update your cart and try again.");
                    }
                }

                StripeConfiguration.ApiKey = _configuration[StripeSettings.SecretKey];

                var orderInfo = _cookieService.GetOrderInfoFromCookie(Request.Cookies[OrderInfoCookie]);

                decimal totalAmount = orderInfo.Order.TotalOrderAmount;
                var currencyCode = orderInfo.Order.Currency.CurrencyCode;

                var options = new ChargeCreateOptions
                {
                    Amount = (long)(totalAmount * 100),
                    Currency = currencyCode.ToLower(),
                    Description = "BioBalance Payment",
                    Source = stripeToken,
                };

                var service = new ChargeService();
                Charge charge = service.Create(options);

                if (charge.Status == "succeeded")
                {
                    foreach (var item in productsInCart.Items)
                    {
                        var result = await _productService.UpdateProductQuantityInStock(item.ProductId, item.QuantityToOrder);
                        if (result == false)
                        {
                            _logger.LogError($"{item.Title} out of stock: PaymentController/Charge/Post");
                            throw new PaymentErrorException($"An error occurred while processing your order. {item.Title} is no longer available. Please update your cart and try again.");
                        }
                    }

                    string orderNumber = await _orderService.CreateOrderAsync(orderInfo, productsInCart, User.Id());

                    if (orderNumber != null)
                    {
                        ViewBag.OrderNumber = orderNumber;
                    }

                    _cookieService.RemoveCookie(Response.Cookies, ShoppingCartCookie);
                    _cookieService.RemoveCookie(Response.Cookies, OrderInfoCookie);

                    ViewBag.CustomerFirstName = orderInfo.Customer.FirstName;

                    return View("PaymentSuccess");
                }
                else
                {
                    return View("PaymentFailed");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PaymentConroller/Charge/Post");
                throw new PaymentErrorException("There was a problem with the payment. Please try again.");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            try
            {
                var publishableKey = _configuration[StripeSettings.PublishableKey];
                ViewBag.PublishableKey = publishableKey;

                var cart = _cookieService.GetOrCreateCartCookie(Request.Cookies[ShoppingCartCookie]);

                if (cart == null || cart.Items.Count() == 0)
                {
                    return RedirectToAction("Index", "Cart");
                }

                var customer = await GeneratePaymentCheckoutGetCustomerModel();
                var order = await GeneratePaymentCheckoutGetOrderModel(cart);
                CheckoutFormModel checkoutModel = await GeneratePaymentCheckoutGetModel(customer, order);

                return View(checkoutModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PaymentConroller/Checkout/Get");
                throw new InternalServerErrorException(InternalServerErrorMessage);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [RequiresCookieConsent]
        public async Task<IActionResult> Checkout(CheckoutFormModel model)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    model.Customer.Countries = await _shopService.AllCountriesAsync();
                    model.Order.Currency = await _shopService.GetShopCurrency();
                    return View(model);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "PaymentConroller/Checkout/Post");
                    throw new InternalServerErrorException(InternalServerErrorMessage);
                }
            }

            try
            {
                _cookieService.SaveOrderInfoInCookie(Response.Cookies, model);

                return RedirectToAction(nameof(Charge));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PaymentConroller/Checkout/Post");
                throw new InternalServerErrorException(InternalServerErrorMessage);
            }
        }


        private async Task<CheckoutCustomerFormModel> GeneratePaymentCheckoutGetCustomerModel()
        {
            var customer = new CheckoutCustomerFormModel();

            if (await _paymentService.ExistsAsync(User.Id()))
            {
                customer = await _paymentService.GetCustomerInfoAsync(User.Id());
            }
            else
            {
                customer.Country = new ShopCountryServiceModel();
            }

            customer.Countries = await _shopService.AllCountriesAsync();
            return customer;
        }

        private async Task<CheckoutOrderFormModel> GeneratePaymentCheckoutGetOrderModel(CartCookieModel cart)
        {
            CartIndexModel productsInCart = await _cartService.GetCartProductsInfo(cart);

            var order = new CheckoutOrderFormModel();
            order.OrderAmount = productsInCart.Items.Select(i => i.Price * i.QuantityToOrder).Sum();
            order.Currency = await _shopService.GetShopCurrency();

            var shippingFeeRate = await _shopService.GetShippingFeeRate() ?? 0;
            order.ShippingFee = Math.Round(shippingFeeRate * order.OrderAmount / 100.00M, 2);

            return order;
        }

        private async Task<CheckoutFormModel> GeneratePaymentCheckoutGetModel(CheckoutCustomerFormModel customer, CheckoutOrderFormModel order)
        {
            var checkoutModel = new CheckoutFormModel()
            {
                Customer = customer,
                Order = order
            };
            return checkoutModel;
        }
    }
}