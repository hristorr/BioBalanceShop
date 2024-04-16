using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Exceptions;
using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Admin.Product;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static BioBalanceShop.Core.Constants.ExceptionErrorMessages;
using static BioBalanceShop.Core.Constants.MessageConstants;

namespace BioBalanceShop.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IProductService _productService;
        private readonly IAdminProductService _adminProductService;
        private readonly IShopService _shopService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public ProductController(
            IProductService productService,
            IAdminProductService adminProductService,
            IShopService shopService,
            UserManager<ApplicationUser> userManager,
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _adminProductService = adminProductService;
            _shopService = shopService;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AdminProductAllServiceModel model)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/ProductController/All/Get");
                throw new InternalServerErrorException(InternalServerErrorMessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (!await _productService.ExistsAsync(id))
                {
                    return BadRequest();
                }

                await _adminProductService.DeleteProductByIdAsync(id);

                return RedirectToAction(nameof(All));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/ProductController/DeleteConfirmed/Post");
                throw new InternalServerErrorException(InternalServerErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (!await _productService.ExistsAsync(id))
                {
                    return BadRequest();
                }

                AdminProductEditFormModel? model = await _adminProductService.GetProductByIdAsync(id);

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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/ProductController/Edit/Get");
                throw new InternalServerErrorException(InternalServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminProductEditFormModel model)
        {
            try
            {
                if (!await _productService.ExistsAsync(model.Id))
                {
                    return BadRequest();
                }

                if (await _adminProductService.ProductCodeExistsAsync(model.ProductCode, model.Id))
                {
                    ModelState.AddModelError(nameof(model.ProductCode), ProductCodeExistsErrorMessage);
                }

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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/ProductController/Edit/Post");
                throw new InternalServerErrorException(InternalServerErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                AdminProductCreateFormModel model = new AdminProductCreateFormModel();

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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/ProductController/Create/Get");
                throw new InternalServerErrorException(InternalServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminProductCreateFormModel model)
        {
            try
            {
                if (await _adminProductService.ProductCodeExistsAsync(model.ProductCode))
                {
                    ModelState.AddModelError(nameof(model.ProductCode), ProductCodeExistsErrorMessage);
                }

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

                await _adminProductService.CreateProductAsync(model, User.Id());

                return RedirectToAction(nameof(All));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Admin/ProductController/Create/Post");
                throw new InternalServerErrorException(InternalServerErrorMessage);
            }
        }
    }
}
