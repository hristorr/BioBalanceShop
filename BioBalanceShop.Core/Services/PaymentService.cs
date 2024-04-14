using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Payment;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository _repository;
        private readonly ICustomerService _customerService;
        public PaymentService(
            IRepository repository,
            ICustomerService customerService)
        {
            _repository = repository;
            _customerService = customerService;
        }

        public async Task CreatePaymentAsync(PaymentCheckoutPostCreatePaymentModel model)
        {
            await _repository.AddAsync(model);
            await _repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string userId)
        {
            return await _repository.AllReadOnly<Customer>()
                .AnyAsync(c => c.UserId == userId);
        }

        public async Task<PaymentCheckoutPostCustomerModel> GetCustomerInfoAsync(string userId)
        {
            var customer = await _repository.AllReadOnly<Customer>()
                .Where(c => c.UserId == userId)
                .Select(c => new PaymentCheckoutPostCustomerModel()
                {
                    FirstName = c.User.FirstName,
                    LastName = c.User.LastName,
                    Email = c.User.Email,
                    PhoneNumber = c.User.PhoneNumber,
                    Country = new PaymentCheckoutPostCountryModel()
                })
                .FirstAsync();

            if (await _customerService.CustomerAddressExists(userId))
            {
                var address = await _customerService.GetCustomerAddress(userId);

                if (address != null)
                {
                    customer.Street = address.Street;
                    customer.PostCode = address.PostCode;
                    customer.City = address.City;
                    customer.Country.Id = address.Country.Id;
                    customer.Country.Name = address.Country.Name;
                }
            }
            
            return customer;
        }
    }
}
