using BioBalanceShop.Attributes;
using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BioBalanceShop.Core.Constants.CookieConstants;

namespace BioBalanceShop.Controllers
{
    public class CartController : BaseController
    {
        private readonly IShopService _shopService;
        private readonly ICookieService _cookieService;
        private readonly ICartService _cartService;
        private readonly ILogger _logger;

        public CartController(
            IShopService shopService,
            ICookieService cookieService,
            ICartService cartService,
            ILogger<CartController> logger)
        {
            _shopService = shopService;
            _cookieService = cookieService;
            _cartService = cartService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [RequiresCookieConsent]
        public IActionResult AddToCart(int productId, int quantity)
        {
            CartCookieModel cart = _cookieService.GetOrCreateCartCookie(Request.Cookies[ShoppingCartCookie]);

            cart.AddProduct(productId, quantity);
            _cookieService.SetCartCookie(Response.Cookies, cart);

            if (quantity == 1)
            {
                TempData["AddedToCartMessage"] = $"{quantity} product successfully added to cart";
            }
            else
            {
                TempData["AddedToCartMessage"] = $"{quantity} products successfully added to cart";
            }

            return RedirectToAction("Details", "Product", new { id = productId });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CartCookieModel cart = _cookieService.GetOrCreateCartCookie(Request.Cookies[ShoppingCartCookie]);
            CartIndexModel productsInCart = await _cartService.GetCartProductsInfo(cart);

            productsInCart.TotalPrice = productsInCart.Items.Select(i => i.Price * i.QuantityToOrder).Sum();
            var currency = await _shopService.GetShopCurrency();

            if (currency != null)
            {
                productsInCart.CurrencySymbol = currency.CurrencySymbol;
                productsInCart.CurrencyIsSymbolPrefix = currency.CurrencyIsSymbolPrefix;
            }         

            return View(productsInCart);
        }

        [AllowAnonymous]
        [HttpPost]
        [RequiresCookieConsent]
        public IActionResult UpdateCart(CartUpdateModel updateModel)
        {
            CartCookieModel cart = _cookieService.GetOrCreateCartCookie(Request.Cookies[ShoppingCartCookie]);

            _cartService.UpdateProductsInCart(updateModel, cart);
            _cookieService.SetCartCookie(Response.Cookies, cart);

            return RedirectToAction("Index");
        }
    }
}