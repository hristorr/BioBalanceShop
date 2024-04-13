using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Admin.Product;
using BioBalanceShop.Core.Models.Admin.User;
using BioBalanceShop.Core.Models.Product;
using BioBalanceShop.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BioBalanceShop.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IProductService _productService;
        private readonly IAdminProductService _adminProductService;
        private readonly IShopService _shopService;
        private readonly ILogger _logger;

        public ProductController(
            IProductService productService,
            IAdminProductService adminProductService,
            IShopService shopService,
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _adminProductService = adminProductService;
            _shopService = shopService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AdminProductAllServiceModel model)
        {
            var products = await _adminProductService.AllAsync(
                model.Category,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.ProductsPerPage);

            model.TotalProductsCount = products.TotalProductsCount;
            model.Products = products.Products;
            model.Categories = await _productService.AllCategoryNamesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _adminProductService.DeleteProductByIdAsync(id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AdminProductEditFormModel? model = await _adminProductService.GetProductByIdAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            model.Categories = await _productService.AllCategoriesAsync();
            var currency = await _shopService.GetShopCurrency();
            model.Currency = new ShopCurrencyServiceModel()
            {
                Id = currency.Id,
                CurrencyCode = currency.CurrencyCode,
                CurrencyIsSymbolPrefix = currency.CurrencyIsSymbolPrefix,
                CurrencySymbol = currency.CurrencySymbol
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminProductEditFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _productService.AllCategoriesAsync();
                var currency = await _shopService.GetShopCurrency();
                model.Currency = new ShopCurrencyServiceModel()
                {
                    Id = currency.Id,
                    CurrencyCode = currency.CurrencyCode,
                    CurrencyIsSymbolPrefix = currency.CurrencyIsSymbolPrefix,
                    CurrencySymbol = currency.CurrencySymbol
                };

                return View(model);
            }

            await _adminProductService.EditProductAsync(model);

            return RedirectToAction(nameof(All), "Product");
        }
    }
}
