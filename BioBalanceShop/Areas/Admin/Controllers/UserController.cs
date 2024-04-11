using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Admin.User;
using BioBalanceShop.Core.Models.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static BioBalanceShop.Core.Constants.AdminConstants;

namespace BioBalanceShop.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService _userService;
        private readonly IMemoryCache _memoryCache;

        public UserController(
            IUserService userService,
            IMemoryCache memoryCache)
        {
            _userService = userService;
            _memoryCache = memoryCache;
        }

        //public async Task<IActionResult> All()
        //{
        //    var model = memoryCache.Get<IEnumerable<UserServiceModel>>(UsersCacheKey);

        //    if (model == null || model.Any() == false)
        //    {
        //        model = await userService.GetAllUsersAsync();

        //        var cacheOptions = new MemoryCacheEntryOptions()
        //            .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

        //        memoryCache.Set(UsersCacheKey, model, cacheOptions);
        //    }

        //    return View(model);
        //}


        [HttpGet]
        public async Task<IActionResult> All([FromQuery] UserAllGetModel model)
        {
            var users = await _userService.AllAsync(
                model.Role,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.UsersPerPage);

            model.TotalUsersCount = users.TotalUsersCount;
            model.Users = users.Users;
            model.Roles = await _userService.GetAllDistinctRoles();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _userService.DeleteUserByIdAsync(id);

            return RedirectToAction(nameof(All));
        }

    }
}
