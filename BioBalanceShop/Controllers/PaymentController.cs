using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models;
using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Core.Models.Payment;
using BioBalanceShop.Core.Services;
using BioBalanceShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using Microsoft.AspNetCore.Identity;
using BioBalanceShop.Infrastructure.Data.Models;
using static BioBalanceShop.Core.Constants.CookieConstants;
using BioBalanceShop.Core.Models._Base;

namespace BioBalanceShop.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly ILogger _logger;

        public PaymentController(
            IConfiguration configuration,
            IProductService productService,
            IShopService shopService,
            IPaymentService paymentService,
            IOrderService orderService,
            ILogger<CartController> logger)
        {
            _configuration = configuration;
            _productService = productService;
            _shopService = shopService;
            _paymentService = paymentService;
            _orderService = orderService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var publishableKey = _configuration["StripeSettings:PublishableKey"];
            ViewBag.PublishableKey = publishableKey;

            var cart = GetOrCreateCart();

            if (cart == null || cart.Items.Count() == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            var customer = await GeneratePaymentCheckoutGetCustomerModel();
            var order = await GeneratePaymentCheckoutGetOrderModel(cart);

            //CartIndexGetModel productsInCart = await GetCartProductInfo(cart);

            //var order = new PaymentCheckoutGetOrderModel();
            //order.OrderAmount = productsInCart.Items.Select(i => i.Price * i.QuantityToOrder).Sum();
            //order.Currency = await _shopService.GetShopCurrency();

            //if (currency != null)
            //{
            //    order.CurrencyCode = currency.CurrencyCode;
            //    order.CurrencySymbol = currency.CurrencySymbol;
            //    order.CurrencyIsSymbolPrefix = currency.CurrencyIsSymbolPrefix;
            //}


            PaymentCheckoutPostModel checkoutModel = await GeneratePaymentCheckoutGetModel(customer, order);

            return View(checkoutModel);
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Charge()
        {
            var publishableKey = _configuration["StripeSettings:PublishableKey"];
            ViewBag.PublishableKey = publishableKey;

            var model = GetOrderInfoFromCookie();
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
        public async Task<IActionResult> Charge(string stripeToken, string stripeEmail)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

           
            var orderInfo = GetOrderInfoFromCookie();

            //var cart = GetOrCreateCart();

            //CartIndexGetModel productsInCart = new CartIndexGetModel();

            //foreach (var item in cart.Items)
            //{
            //    if (await _productService.ExistsAsync(item.ProductId))
            //    {
            //        CartIndexGetProductModel product = await _productService.GetProductFromCart(item.ProductId, item.Quantity);
            //        productsInCart.Items.Add(product);
            //    }
            //}

            //decimal totalAmount = productsInCart.Items.Select(i => i.Price * i.QuantityToOrder).Sum();
            //var currencyInfo = await _shopService.GetShopCurrency();
            //var currencyCode = currencyInfo.CurrencyCode;



            decimal totalAmount = orderInfo.Order.TotalOrderAmount;
            var currencyCode = orderInfo.Order.Currency.CurrencyCode;


            if (currencyCode == null)
            {
                throw new Exception("Internal server error");
            }

            var options = new ChargeCreateOptions
            {
                Amount = (long)(totalAmount * 100), // replace with the actual amount in cents
                Currency = currencyCode.ToLower(),
                Description = "BioBalance Payment",
                Source = stripeToken,
                ReceiptEmail = stripeEmail,
            };

            var service = new ChargeService();
            Charge charge = service.Create(options);

            // Handle success or failure based on charge status
            if (charge.Status == "succeeded")
            {
                try
                {
                    var cart = GetOrCreateCart();
                    CartIndexGetModel productsInCart = await GetCartProductInfo(cart);

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

                //Empty cookie content
                RemoveCookie(ShoppingCartCookie);
                RemoveCookie(OrderInfoCookie);

                
                ViewBag.CustomerFirstName = orderInfo.Customer.FirstName;

                // Payment success
                return View("PaymentSuccess");
            }
            else
            {
                // Payment failed
                return View("PaymentFailed");
            }
        }


      

        //[IgnoreAntiforgeryToken]

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Checkout(PaymentCheckoutPostModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Customer.Countries = await _shopService.AllCountriesAsync();
                model.Order.Currency = await _shopService.GetShopCurrency();
                return View(model);
            }

            SaveOrderInfoInCookie(model);
            return RedirectToAction(nameof(Charge));
        }


        private PaymentCheckoutPostModel GetOrderInfoFromCookie()
        {
            PaymentCheckoutPostModel orderInfo;
            string? orderCookie = Request.Cookies[OrderInfoCookie];

            if (string.IsNullOrEmpty(orderCookie))
            {
                orderInfo = null;
            }
            else
            {
                orderInfo = JsonConvert.DeserializeObject<PaymentCheckoutPostModel>(orderCookie);
            }

            return orderInfo;
        }

        private void SaveOrderInfoInCookie(PaymentCheckoutPostModel model)
        {
            string orderInfo = JsonConvert.SerializeObject(model);
            Response.Cookies.Append(OrderInfoCookie, orderInfo, new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = true,
                Secure = true
            });

        }


        private CartCookieModel GetOrCreateCart()
        {
            CartCookieModel cart;
            string? cartCookie = Request.Cookies[ShoppingCartCookie];

            if (string.IsNullOrEmpty(cartCookie))
            {
                cart = null;
            }
            else
            {
                cart = JsonConvert.DeserializeObject<CartCookieModel>(cartCookie);
            }

            return cart;
        }

        private async Task<CartIndexGetModel> GetCartProductInfo(CartCookieModel cart)
        {
            CartIndexGetModel productsInCart = new CartIndexGetModel();

            foreach (var item in cart.Items)
            {
                if (await _productService.ExistsAsync(item.ProductId))
                {
                    CartIndexGetProductModel product = await _productService.GetProductFromCart(item.ProductId, item.Quantity);
                    productsInCart.Items.Add(product);
                }
            }

            return productsInCart;
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
            CartIndexGetModel productsInCart = await GetCartProductInfo(cart);

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

        private void RemoveCookie(string cookie)
        {
            Response.Cookies.Append(cookie, "", new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1)
            });
        }
    }
}
