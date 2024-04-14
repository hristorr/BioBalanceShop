using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Admin.User;
using BioBalanceShop.Core.Models.Product;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using static BioBalanceShop.Core.Constants.AdminConstants;
using static BioBalanceShop.Core.Constants.RoleConstants;
using static BioBalanceShop.Infrastructure.Constants.CustomClaims;

namespace BioBalanceShop.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AdminUserAllGetModel model)
        {
            var users = await _userService.AllAsync(
                model.Role,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.UsersPerPage);

            model.TotalUsersCount = users.TotalUsersCount;
            model.Users = users.Users;
            model.Roles = await _userService.GetAllRoles();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser.Id == id)
            {
                await _userService.DeleteUserByIdAsync(id);
                await _signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            await _userService.DeleteUserByIdAsync(id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            AdminUserEditFormModel model = await _userService.GetUserByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminUserEditFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var currentUser = await _userManager.GetUserAsync(User);
            var modelUser = await _userManager.FindByIdAsync(model.Id);

            var modelUserName = $"{modelUser.FirstName} {modelUser.LastName}";
            var modelUserClaims = await _userManager.GetClaimsAsync(modelUser);
            var modelUserFullNameClaim = modelUserClaims.FirstOrDefault(c => c.Value == modelUserName);
            var newFullNameClaim = new Claim(UserFullNameClaim, $"{model.FirstName} {model.LastName}");

            await _userService.EditUserAsync(model);

            await _userManager.ReplaceClaimAsync(modelUser, modelUserFullNameClaim, newFullNameClaim);

            if (currentUser != null && await _userManager.IsInRoleAsync(currentUser, AdminRole) == false)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            if (currentUser.Id == model.Id)
            {
                await _signInManager.RefreshSignInAsync(currentUser);
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AdminUserCreateFormModel model = new AdminUserCreateFormModel();
            model.Roles = await _userService.GetAllRoles();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminUserCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Roles = await _userService.GetAllRoles();
                return View(model);
            }

            await _userService.CreateUserAsync(model);

            return RedirectToAction(nameof(All));
        }
    }
}
