using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Admin.Order;
using BioBalanceShop.Core.Models.Admin.Product;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BioBalanceShop.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        private readonly IAdminOrderService _adminOrderService;
        private readonly IShopService _shopService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public OrderController(
            IAdminOrderService adminOrderService,
            IShopService shopService,
            UserManager<ApplicationUser> userManager,
            ILogger<ProductController> logger)
        {
            _adminOrderService = adminOrderService;
            _shopService = shopService;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AdminOrderAllGetModel model)
        {
            var orders = await _adminOrderService.AllAsync(
                model.OrderStatus,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.OrdersPerPage);

            model.TotalOrdersCount = orders.TotalOrdersCount;
            model.Orders = orders.Orders;
            model.OrderStatuses = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditStatus(int id)
        {
            var model = await _adminOrderService.GetOrderByIdAsync(id);
            model.OrderStatuses = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditStatus(AdminOrderDetailsServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _adminOrderService.UpdateOrderStatus(model.Id, model.Status);

            return RedirectToAction(nameof(All));
        }
    }
}
