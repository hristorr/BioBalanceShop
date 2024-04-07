using BioBalanceShop.Core.Models.Payment;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BioBalanceShop.Core.Constants.RoleConstants;

namespace BioBalanceShop.Controllers
{
    public class OrderController : BaseController
    {
        [Authorize(Roles = CustomerRole)]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //public Task<IActionResult> Create(PaymentCheckoutPostCreatePaymentModel model)
        //{
           


        //}
    }
}
