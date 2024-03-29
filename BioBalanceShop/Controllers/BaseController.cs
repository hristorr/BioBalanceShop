using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioBalanceShop.Controllers
{
    [Authorize(Roles = "admin")]
    public class BaseController : Controller
    {

    }
}
