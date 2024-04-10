using BioBalanceShop.Core.Models.Admin.User;
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
    }
}
