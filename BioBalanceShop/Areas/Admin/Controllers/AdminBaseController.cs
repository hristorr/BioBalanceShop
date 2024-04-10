using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BioBalanceShop.Core.Constants.RoleConstants;
using static BioBalanceShop.Core.Constants.AdminConstants;

namespace BioBalanceShop.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
        
    }
}
