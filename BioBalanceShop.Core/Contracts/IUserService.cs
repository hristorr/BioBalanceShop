﻿using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Admin.User;
using BioBalanceShop.Core.Models.Product;
using BioBalanceShop.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<AdminUserServiceModel>> GetAllUsersAsync();

        Task<string> GetUserFullNameAsync(string userId);

        Task<AdminUserQueryServiceModel> AllAsync(
          string? role = null,
          string? searchTerm = null,
          UserSorting sorting = UserSorting.Newest,
          int currentPage = 1,
          int usersPerPage = 1);

        Task DeleteUserByIdAsync(string userId);

        Task EditUserAsync(AdminUserEditFormModel model);

        Task<AdminUserEditFormModel?> GetUserByIdAsync(string userId);

        Task<string> GetUserRole(ApplicationUser user);

        Task<IEnumerable<string>> GetAllRoles();

        Task CreateUserAsync(AdminUserCreateFormModel model);

        Task<bool> UserIsActive(string userId);
    }
}
