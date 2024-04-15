﻿using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Exceptions;
using BioBalanceShop.Core.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BioBalanceShop.Core.Constants.ExceptionErrorMessages;

namespace BioBalanceShop.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        private readonly ILogger _logger;

        public ProductController(
            IProductService productService,
            IShopService shopService,
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _shopService = shopService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProductAllServiceModel model)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductConroller/All/Get");
                throw new InternalServerErrorException(InternalServerErrorMessage);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _productService.GetProductByIdAsync(id);

            if (model == null) {
                return BadRequest();
            }

            string? addedToCartMessage = TempData["AddedToCartMessage"] as string;

            if (!string.IsNullOrEmpty(addedToCartMessage))
            {
                ViewBag.AddedToCartMessage = addedToCartMessage;
            }
            
            return View(model);
        }
    }
}
