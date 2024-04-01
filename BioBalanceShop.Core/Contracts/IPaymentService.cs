using BioBalanceShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Contracts
{
    public interface IPaymentService
    {
        Task<bool> ExistsAsync(string userId);
        Task<CheckoutCustomerServiceModel> GetCustomerInfoAsync(string userId);
    
    }
}
