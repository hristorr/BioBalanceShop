using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Admin.User;
using BioBalanceShop.Core.Models.Product;
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

        Task<IEnumerable<string>> GetAllDistinctRoles();

        Task DeleteUserByIdAsync(string userId);
    }
}
