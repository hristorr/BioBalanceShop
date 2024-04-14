using BioBalanceShop.Core.Enumerations;
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
        Task<IEnumerable<UserServiceModel>> GetAllUsersAsync();

        Task<string> GetUserFullNameAsync(string userId);

        Task<UserQueryServiceModel> AllAsync(
          string? role = null,
          string? searchTerm = null,
          UserSorting sorting = UserSorting.Newest,
          int currentPage = 1,
          int usersPerPage = 1);

        Task DeleteUserByIdAsync(string userId);

        Task EditUserAsync(UserEditFormModel model);

        Task<UserEditFormModel> GetUserByIdAsync(string userId);

        Task<string> GetUserRole(ApplicationUser user);

        Task<IEnumerable<string>> GetAllRoles();

        Task CreateUserAsync(UserCreateFormModel model);

        Task<bool> UserIsActive(string userId);
    }
}
