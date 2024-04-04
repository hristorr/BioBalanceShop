using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BioBalanceShop.Core.Constants.RoleConstants;

namespace BioBalanceShop.Controllers
{
    [Authorize(Roles = AdminRole)]
    public class BaseController : Controller
    {

    }
}
