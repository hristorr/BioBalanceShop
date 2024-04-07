using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository _repository;

        public CustomerService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateCustomerAsync(string userId)
        {
            var customer = new Customer()
            {
                UserId = userId
            };

            await _repository.AddAsync(customer);
            await _repository.SaveChangesAsync();
        }

        public async Task<int?> GetCustomerIdByUserIdAsync(string userId)
        {
            var customer = await _repository
                .AllReadOnly<Customer>()
                .Where(c => c.UserId == userId)
                .Select(c => new { c.Id })
                .FirstOrDefaultAsync();

            return customer?.Id;
        }
    }
}
