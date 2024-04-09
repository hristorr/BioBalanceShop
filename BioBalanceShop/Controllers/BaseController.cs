using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BioBalanceShop.Core.Constants.RoleConstants;

namespace BioBalanceShop.Controllers
{
    [Authorize(Roles = CustomerRole)]
    public class BaseController : Controller
    {

    }
}
