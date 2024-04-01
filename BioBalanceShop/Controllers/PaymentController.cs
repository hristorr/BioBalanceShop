using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models;
using BioBalanceShop.Core.Services;
using BioBalanceShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;

namespace BioBalanceShop.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        private readonly IPaymentService _paymentService;
        private readonly ILogger _logger;

        public PaymentController(
            IConfiguration configuration,
            IProductService productService,
            IShopService shopService,
            IPaymentService paymentService,
            ILogger<CartController> logger)
        {
            _configuration = configuration;
            _productService = productService;
            _shopService = shopService;
            _paymentService = paymentService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var publishableKey = _configuration["StripeSettings:PublishableKey"];
            ViewBag.PublishableKey = publishableKey;

            var cart = GetOrCreateCart();

            if (cart == null)
            {
                return RedirectToAction("Index", "Cart");
            }

            CartServiceModel productsInCart = new CartServiceModel();

            foreach (var item in cart.Items)
            {
                if (await _productService.ExistsAsync(item.ProductId))
                {
                    CartItemServiceModel product = await _productService.GetProductFromCart(item.ProductId, item.Quantity);
                    productsInCart.Items.Add(product);
                }
            }

            var order = new CheckoutOrderServiceModel();

            order.OrderAmount = productsInCart.Items.Select(i => i.Price * i.QuantityToOrder).Sum();
            var currency = await _shopService.GetShopCurrency();

            if (currency != null)
            {
                order.CurrencyCode = currency.CurrencyCode;
                order.CurrencySymbol = currency.CurrencySymbol;
                order.CurrencyIsSymbolPrefix = currency.CurrencyIsSymbolPrefix;
            }

            var shippingFeeRate = await _shopService.GetShippingFeeRate() ?? 0;

            order.ShippingFee = Math.Round(shippingFeeRate * order.OrderAmount / 100.00M, 2);

            var customer = new CheckoutCustomerServiceModel();

            if (await _paymentService.ExistsAsync(User.Id()))
            {
                customer = await _paymentService.GetCustomerInfoAsync(User.Id());
            }

            var countries = await _shopService.AllCountriesAsync();
            customer.Countries = countries;

            var checkoutModel = new CheckoutServiceModel()
            {
                Customer = customer,
                Order = order
            };

            return View(checkoutModel);
        }

        [IgnoreAntiforgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Charge(string stripeToken, string stripeEmail)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

            var cart = GetOrCreateCart();

            CartServiceModel productsInCart = new CartServiceModel();

            foreach (var item in cart.Items)
            {
                if (await _productService.ExistsAsync(item.ProductId))
                {
                    CartItemServiceModel product = await _productService.GetProductFromCart(item.ProductId, item.Quantity);
                    productsInCart.Items.Add(product);
                }
            }

            decimal totalAmount = productsInCart.Items.Select(i => i.Price * i.QuantityToOrder).Sum();
            var currencyInfo = await _shopService.GetShopCurrency();
            var currencyCode = currencyInfo.CurrencyCode;

            if (currencyCode == null)
            {
                throw new Exception("Internal server error");
            }

            var options = new ChargeCreateOptions
            {
                Amount = (long)(totalAmount * 100), // replace with the actual amount in cents
                Currency = currencyCode.ToLower(),
                Description = "Example Charge",
                Source = stripeToken,
                ReceiptEmail = stripeEmail,
            };

            var service = new ChargeService();
            Charge charge = service.Create(options);

            // Handle success or failure based on charge status
            if (charge.Status == "succeeded")
            {
                // Payment success
                return View("PaymentSuccess");
            }
            else
            {
                // Payment failed
                return View("PaymentFailed");
            }
        }

        private CartCookieModel GetOrCreateCart()
        {
            CartCookieModel cart;
            string? cartCookie = Request.Cookies["ShoppingCart"];

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
    }
}
