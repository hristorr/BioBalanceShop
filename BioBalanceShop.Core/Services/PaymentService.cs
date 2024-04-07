﻿using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Payment;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository _repository;

        public PaymentService(IRepository repository)
        {
            _repository = repository;
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
            return await _repository.AllReadOnly<Customer>()
                .Where(c => c.UserId == userId)
                .Select(c => new PaymentCheckoutPostCustomerModel()
                {
                    FirstName = c.User.FirstName,
                    LastName = c.User.LastName,
                    Email = c.User.Email,
                    PhoneNumber = c.User.PhoneNumber,
                    Street = c.Address.Street,
                    PostCode = c.Address.PostCode,
                    City = c.Address.City,
                    Country = new PaymentCheckoutPostCountryModel()
                    {
                        Id = c.Address.Country.Id,
                        Name = c.Address.Country.Name
                    }
                })
                .FirstAsync();
        }
    }
}
