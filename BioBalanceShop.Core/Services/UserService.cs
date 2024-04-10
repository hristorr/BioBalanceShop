using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Admin.User;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BioBalanceShop.Core.Constants.RoleConstants;

namespace BioBalanceShop.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IRepository repository,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _repository = repository;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IEnumerable<UserServiceModel>> GetAllUsersAsync()
        {
            var usersWithRolesAndNames = new List<UserServiceModel>();

            var users = _userManager.Users.ToList();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var userWithRolesAndNames = new UserServiceModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = roles.ToList()
                };

                usersWithRolesAndNames.Add(userWithRolesAndNames);
            }

            return usersWithRolesAndNames;
        }

        public async Task<string> GetUserFullNameAsync(string userId)
        {
            string result = string.Empty;
            var user = await _repository
                .GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }

    }
}
