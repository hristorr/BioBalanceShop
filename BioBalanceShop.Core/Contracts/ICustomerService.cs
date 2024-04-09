using BioBalanceShop.Core.Models.Customer;
using BioBalanceShop.Core.Models.Payment;
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

        Task<bool> IsCustomer(string userId);

        Task<bool> CustomerAddressExists(string userId);
        Task<CustomerAddressServiceModel?> GetCustomerAddress(string userId);

        Task<CustomerAddressFormModel?> GetCustomerAddressFormModel(string userId);

        Task EditCustomerAddressAsync(CustomerAddressFormModel model, string userId);

        Task CreateCustomerAddressAsync(CustomerAddressFormModel model, string userId);
    }
}
