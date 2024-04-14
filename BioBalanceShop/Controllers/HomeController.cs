using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Services;
using BioBalanceShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BioBalanceShop.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(
            ILogger<HomeController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _productService.GetLastFiveProductsAsync();
            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {

            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}
