using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BioBalanceShop.Controllers
{
    public class CartController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        private readonly ILogger _logger;

        public CartController(
            IProductService productService,
            IShopService shopService,
            ILogger<CartController> logger)
        {
            _productService = productService;
            _shopService = shopService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CartCookieModel cart = GetOrCreateCart();

            CartIndexGetModel productsInCart = new CartIndexGetModel();

            foreach (var item in cart.Items)
            {
                if (await _productService.ExistsAsync(item.ProductId))
                {
                    CartIndexGetProductModel product = await _productService.GetProductFromCart(item.ProductId, item.Quantity);
                    productsInCart.Items.Add(product);
                }
            }

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
        public IActionResult AddToCart(int productId, int quantity)
        {
            CartCookieModel cart = GetOrCreateCart();
            cart.AddProduct(productId, quantity);

            string cartJson = JsonConvert.SerializeObject(cart);
            Response.Cookies.Append("ShoppingCart", cartJson, new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = true,
                Secure = true
            });

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult UpdateCart(CartUpdateModel updateModel)
        {
            CartCookieModel cart = GetOrCreateCart();

            foreach (var kvp in updateModel.ProductQuantities)
            {
                CartItemCookieModel? itemToUpdate = cart.Items.FirstOrDefault(item => item.ProductId == kvp.Key);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Quantity = kvp.Value;
                }
            }

            foreach (int productId in updateModel.RemovedProductIds)
            {
                cart.Items.RemoveAll(item => item.ProductId == productId);
            }

            string cartJson = JsonConvert.SerializeObject(cart);
            Response.Cookies.Append("ShoppingCart", cartJson, new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = true,
                Secure = true
            });

            return RedirectToAction("Index");
        }


        private CartCookieModel GetOrCreateCart()
        {
            CartCookieModel cart;
            string? cartCookie = Request.Cookies["ShoppingCart"];

            if (string.IsNullOrEmpty(cartCookie))
            {
                cart = new CartCookieModel();
            }
            else
            {
                cart = JsonConvert.DeserializeObject<CartCookieModel>(cartCookie);
            }

            return cart;
        }
    }
}
