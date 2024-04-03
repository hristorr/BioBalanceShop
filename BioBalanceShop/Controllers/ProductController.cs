using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioBalanceShop.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        private readonly ILogger _logger;

        public ProductController(
            IProductService productService,
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProductAllGetModel model)
        {
            var products = await _productService.AllAsync(
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _productService.GetProductByIdAsync(id);

            if (model == null) {
                return BadRequest();
            }

            return View(model);
        }
    }
}
