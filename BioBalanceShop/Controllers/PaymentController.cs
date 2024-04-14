using BioBalanceShop.Attributes;
using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Core.Models.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Security.Claims;
using static BioBalanceShop.Core.Constants.CookieConstants;
using static BioBalanceShop.Infrastructure.Constants.ConfigurationConstants;

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

        [IgnoreAntiforgeryToken]
        [AllowAnonymous]
        [HttpPost]
        [RequiresCookieConsent]
        public async Task<IActionResult> Charge(string stripeToken, string stripeEmail)
        {
            StripeConfiguration.ApiKey = _configuration[StripeSettings.SecretKey];

            var orderInfo = _cookieService.GetOrderInfoFromCookie(Request.Cookies[OrderInfoCookie]);

            decimal totalAmount = orderInfo.Order.TotalOrderAmount;
            var currencyCode = orderInfo.Order.Currency.CurrencyCode;

            if (currencyCode == null)
            {
                throw new Exception("Internal server error");
            }

            var options = new ChargeCreateOptions
            {
                Amount = (long)(totalAmount * 100),
                Currency = currencyCode.ToLower(),
                Description = "BioBalance Payment",
                Source = stripeToken,
                ReceiptEmail = stripeEmail,
            };

            var service = new ChargeService();
            Charge charge = service.Create(options);

            if (charge.Status == "succeeded")
            {
                try
                {
                    var cart = _cookieService.GetOrCreateCartCookie(Request.Cookies[ShoppingCartCookie]);
                    CartIndexGetModel productsInCart = await _cartService.GetCartProductsInfo(cart);

                    string orderNumber = await _orderService.CreateOrderAsync(orderInfo, productsInCart, User.Id());

                    if (orderNumber != null)
                    {
                        ViewBag.OrderNumber = orderNumber;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "PaymentController/Charge/CreatePaymentAsync");
                    throw new Exception("Internal Server Error");
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Checkout()
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
            PaymentCheckoutPostModel checkoutModel = await GeneratePaymentCheckoutGetModel(customer, order);

            return View(checkoutModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [RequiresCookieConsent]
        public async Task<IActionResult> Checkout(PaymentCheckoutPostModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Customer.Countries = await _shopService.AllCountriesAsync();
                model.Order.Currency = await _shopService.GetShopCurrency();
                return View(model);
            }

            _cookieService.SaveOrderInfoInCookie(Response.Cookies, model);

            return RedirectToAction(nameof(Charge));
        }


        private async Task<PaymentCheckoutPostCustomerModel> GeneratePaymentCheckoutGetCustomerModel()
        {
            var customer = new PaymentCheckoutPostCustomerModel();

            if (await _paymentService.ExistsAsync(User.Id()))
            {
                customer = await _paymentService.GetCustomerInfoAsync(User.Id());
            }
            else
            {
                customer.Country = new PaymentCheckoutPostCountryModel();
            }
                        
            customer.Countries = await _shopService.AllCountriesAsync();
            return customer;
        }

        private async Task<PaymentCheckoutPostOrderModel> GeneratePaymentCheckoutGetOrderModel(CartCookieModel cart)
        {
            CartIndexGetModel productsInCart = await _cartService.GetCartProductsInfo(cart);

            var order = new PaymentCheckoutPostOrderModel();
            order.OrderAmount = productsInCart.Items.Select(i => i.Price * i.QuantityToOrder).Sum();
            order.Currency = await _shopService.GetShopCurrency();

            var shippingFeeRate = await _shopService.GetShippingFeeRate() ?? 0;
            order.ShippingFee = Math.Round(shippingFeeRate * order.OrderAmount / 100.00M, 2);

            return order;
        }

        private async Task<PaymentCheckoutPostModel> GeneratePaymentCheckoutGetModel(PaymentCheckoutPostCustomerModel customer, PaymentCheckoutPostOrderModel order)
        {
            var checkoutModel = new PaymentCheckoutPostModel()
            {
                Customer = customer,
                Order = order
            };
            return checkoutModel;
        }
    }
}
