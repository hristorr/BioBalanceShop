using BioBalanceShop.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Contracts
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(string userId);

        Task<int?> GetCustomerIdByUserIdAsync(string userId);
    }
}
