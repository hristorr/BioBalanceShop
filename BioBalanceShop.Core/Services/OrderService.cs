using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Core.Models.Payment;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using Microsoft.AspNetCore.Identity;
using static BioBalanceShop.Infrastructure.Constants.DataConstants;

namespace BioBalanceShop.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository _repository;
        private readonly ICustomerService _customerService;

        public OrderService(
            IRepository repository,
            ICustomerService customerService)
        {
            _repository = repository;
            _customerService = customerService;
        }

        public async Task CreateOrderAsync(PaymentCheckoutPostModel model, CartIndexGetModel productsInCart, string userId)
        {
            
            Payment payment = new Payment()
            {
                PaymentDate = DateTime.Now,
                PaymentAmount = model.Order.TotalOrderAmount,
                PaymentStatus = PaymentStatus.Success
            };

            OrderRecipient orderRecipient = new OrderRecipient()
            {
                FirstName = model.Customer.FirstName,
                LastName = model.Customer.LastName,
                PhoneNumber = model.Customer.PhoneNumber,
                EmailAddress = model.Customer.Email
            };

            OrderAddress orderAddress = new OrderAddress()
            {
                Street = model.Customer.Street,
                PostCode = model.Customer.PostCode,
                City = model.Customer.City,
                CountryId = model.Customer.Country.Id
            };

            //Add order items

            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var product in productsInCart.Items)
            {
                orderItems.Add(new OrderItem() { 
                    Quantity = product.QuantityToOrder,
                    Price = product.Price,
                    CurrencyId = product.Currency.Id
                });
            }

            Order order = new Order()
            {
                OrderNumber = GenerateOrderNumber(await GetLastOrderNumberAsync()),
                OrderDate = DateTime.Now,
                Status = OrderStatus.Processing,
                Amount = model.Order.OrderAmount,
                ShippingFee = model.Order.ShippingFee,
                TotalAmount = model.Order.TotalOrderAmount,
                CurrencyId = model.Order.Currency.Id,
                Payment = payment,
                OrderAddress = orderAddress,
                OrderRecipient = orderRecipient,
                OrderItems = orderItems
            };

            
            if (userId != null)
            {
                order.CustomerId = await _customerService.GetCustomerIdByUserIdAsync(userId);
            }
            
            await _repository.AddAsync<Order>(order);
            await _repository.SaveChangesAsync();
        }


        private string GenerateOrderNumber(int lastOrderNumber)
        {
            lastOrderNumber++;
            return "PO" + lastOrderNumber.ToString("D6");
        }

        //private async Task<int> GetLastOrderNumberAsync()
        //{
        //    return await _repository.AllReadOnly<Order>()
        //        .Select(o => new
        //        {
        //            PoNumber = int.Parse(o.OrderNumber.Substring(2))
        //        })
        //        .OrderByDescending(o => o.PoNumber)
        //        .Take(1)
        //        .Select(o => o.PoNumber)
        //        .FirstOrDefaultAsync();
        //}

        private async Task<int> GetLastOrderNumberAsync()
        {
            return await _repository.AllReadOnly<Order>()
                .OrderByDescending(o => o.OrderNumber)
                .Select(o => int.Parse(o.OrderNumber.Substring(2)))
                .Take(1)
                .FirstOrDefaultAsync();
        }
    }
}
