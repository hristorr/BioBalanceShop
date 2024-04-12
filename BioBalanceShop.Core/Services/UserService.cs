using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Admin.User;
using BioBalanceShop.Core.Models.Product;
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
                    CreatedDate = DateTime.Now,
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

        public async Task<UserQueryServiceModel> AllAsync(string? role = null, string? searchTerm = null, UserSorting sorting = UserSorting.Newest, int currentPage = 1, int usersPerPage = 1)
        {
            //var usersToShow = _repository.AllReadOnly<ApplicationUser>();
            var usersToShow = await GetAllUsersAsync();

            if (role != null)
            {
                usersToShow = usersToShow
                    .Where(u => u.Roles.Contains(role));
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                usersToShow = usersToShow
                    .Where(u => (u.UserName.ToLower().Contains(normalizedSearchTerm) ||
                                u.Email.ToLower().Contains(normalizedSearchTerm) ||
                                u.FirstName.ToLower().Contains(normalizedSearchTerm) ||
                                u.LastName.ToLower().Contains(normalizedSearchTerm) ||
                                u.PhoneNumber.ToLower().Contains(normalizedSearchTerm)));
            }

            usersToShow = sorting switch
            {
                UserSorting.Newest => usersToShow
                    .OrderByDescending(u => u.CreatedDate),
                UserSorting.Oldest => usersToShow
                .OrderBy(u => u.CreatedDate),
                UserSorting.UserNameAscending => usersToShow
                .OrderBy(u => u.UserName),
                UserSorting.UserNameDescending => usersToShow
                .OrderByDescending(u => u.UserName),
                UserSorting.FirstNameAscending => usersToShow
                .OrderBy(u => u.FirstName),
                UserSorting.FirstNameDescending => usersToShow
                .OrderByDescending(u => u.FirstName),
                UserSorting.LastNameAscending => usersToShow
                .OrderBy(u => u.LastName),
                UserSorting.LastNameDescending => usersToShow
                .OrderByDescending(u => u.LastName),
                _ => usersToShow
                    .OrderByDescending(u => u.CreatedDate)
            };

            var users = usersToShow
                .Skip((currentPage - 1) * usersPerPage)
                .Take(usersPerPage)
            //.ProjectToUserServiceModel()
                .ToList();

            int totalUsers = usersToShow.Count();

            return new UserQueryServiceModel()
            {
                Users = users,
                TotalUsersCount = totalUsers
            };
        }

        //public async Task<IEnumerable<string>> GetAllDistinctRoles()
        //{
        //    var users = await _userManager.Users.ToListAsync();

        //    var distinctRoles = new HashSet<string>();

        //    foreach (var user in users)
        //    {
        //        var roles = await _userManager.GetRolesAsync(user);
        //        foreach (var role in roles)
        //        {
        //            if (!distinctRoles.Contains(role))
        //            {
        //                distinctRoles.Add(role);
        //            }
        //        }
        //    }

        //    return distinctRoles;
        //}

        public async Task DeleteUserByIdAsync(string userId)
        {
            var user = await _repository.GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                user.IsActive = false;
                await _repository.SaveChangesAsync();
            }
        }

        public async Task EditUserAsync(UserFormModel model)
        {
            //var userToEdit = await _repository.All<ApplicationUser>()
            //    .Where(u => u.Id == userId)
            //    .FirstOrDefaultAsync();

            var userToEdit = await _userManager.FindByIdAsync(model.Id);

            if (userToEdit  != null)
            {
                userToEdit.UserName = model.UserName;
                userToEdit.FirstName = model.FirstName;
                userToEdit.LastName = model.LastName;
                userToEdit.Email = model.Email;
                userToEdit.PhoneNumber = model.PhoneNumber;

                if (!await _userManager.IsInRoleAsync(userToEdit, model.Role))
                {
                    //var currentUserRoles = await _userManager
                    //    .GetRolesAsync(userToEdit);

                    //var currentUserRole = string.Empty;

                    //if (currentUserRoles != null)
                    //{
                    //    currentUserRole = currentUserRoles.FirstOrDefault();
                    //}

                    //var currentUserRole = await GetUserRole(userToEdit);

                    var currentRoles = await _userManager.GetRolesAsync(userToEdit);
                    await _userManager.RemoveFromRolesAsync(userToEdit, currentRoles);
                    await _userManager.AddToRoleAsync(userToEdit, model.Role);
                    //if (currentUserRole != model.Role)
                    //{
                    //    await _userManager.AddToRoleAsync(userToEdit, model.Role);
                    //    await _userManager.RemoveFromRoleAsync(userToEdit, currentUserRole);
                    //    await _repository.SaveChangesAsync();
                    //}

                    
                    
                }

                await _userManager.UpdateAsync(userToEdit);
            }
        }
        
        public async Task<string> GetUserRole(ApplicationUser user)
        {
            //var currentUserRoles = await _userManager
            //            .GetRolesAsync(user);
            var currentRoles = await _userManager.GetRolesAsync(user);
            //string currentRole = string.Empty; ;
            //if (currentUserRoles != null)
            //{
            //    currentUserRole = currentUserRoles.First();
            //}

            return currentRoles.First();
        }

        public async Task<IEnumerable<string>> GetAllRoles()
        {
            return await _roleManager.Roles
                .Select(r => r.Name)
                .ToListAsync();
        }

        public async Task<UserFormModel> GetUserByIdAsync(string userId)
        {
            var user = await _repository.GetByIdAsync<ApplicationUser>(userId);

            var model = new UserFormModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = await GetUserRole(user),
                Roles = await GetAllRoles()
            };

            return model;
        }
    }
}
