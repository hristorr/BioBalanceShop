using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Order;
using BioBalanceShop.Core.Models.Payment;
using BioBalanceShop.Core.Models.Product;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static BioBalanceShop.Core.Constants.RoleConstants;
using System.Security.Claims;

namespace BioBalanceShop.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public OrderController(
            IOrderService orderService,
            UserManager<ApplicationUser> userManager,
            ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _userManager = userManager;
            _logger = logger;
        }


        //[Authorize(Roles = CustomerRole)]
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}


        [Authorize(Roles = CustomerRole)]
        [HttpGet]
        public async Task<IActionResult> MyOrders([FromQuery] OrderAllGetModel model)
        {
            var orders = await _orderService.AllAsync(
                model.OrderStatus,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.OrdersPerPage,
                User.Id());

            model.TotalOrdersCount = orders.TotalOrdersCount;
            model.Orders = orders.Orders;
            model.OrderStatuses = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();

            //await _productService.AllCategoryNamesAsync();

            return View(model);
        }

    }
}
