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
using BioBalanceShop.Core.Models.Product;
using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Order;

namespace BioBalanceShop.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository _repository;
        private readonly ICustomerService _customerService;
        private readonly IShopService _shopService;

        public OrderService(
            IRepository repository,
            ICustomerService customerService,
            IShopService shopService)
        {
            _repository = repository;
            _customerService = customerService;
            _shopService = shopService;
        }

        public async Task<OrderQueryServiceModel> AllAsync(OrderStatus? orderStatus = 0, string? searchTerm = null, OrderSorting sorting = OrderSorting.OrderDateDescending, int currentPage = 1, int ordersPerPage = 1, string? userId = null)
        {
            var ordersToShow = _repository.AllReadOnly<Order>()
                .Where(o => o.CustomerId != null && o.Customer.UserId == userId);

            if (orderStatus != 0)
            {
                ordersToShow = ordersToShow
                    .Where(o => o.Status == orderStatus);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                //string input = "Value2";

                //MyEnum enumValue;
                //if (Enum.TryParse(input, out enumValue))
                //{
                //    if (Enum.IsDefined(typeof(MyEnum), enumValue))
                //    {
                //    }
                //}

                        ordersToShow = ordersToShow
                    .Where(o => o.OrderNumber.ToLower().Contains(normalizedSearchTerm));
            }

            ordersToShow = sorting switch
            {
                OrderSorting.OrderDateDescending => ordersToShow
                    .OrderByDescending(o => o.OrderDate),
                OrderSorting.OrderDateAscending => ordersToShow
                .OrderBy(o => o.OrderDate),
                OrderSorting.AmountAscending => ordersToShow
                    .OrderBy(o => o.TotalAmount),
                OrderSorting.AmountDescending => ordersToShow
                    .OrderByDescending(o => o.TotalAmount),
                _ => ordersToShow
                    .OrderByDescending(o => o.OrderDate)
            };

            var orders = await ordersToShow
                .Skip((currentPage - 1) * ordersPerPage)
                .Take(ordersPerPage)
                .ProjectToOrderServiceModel()
                .ToListAsync();

            int totalOrders = await ordersToShow.CountAsync();

            var currency = await _shopService.GetShopCurrency();

            foreach (var order in orders)
            {
                order.Currency = currency;
            }

            return new OrderQueryServiceModel()
            {
                Orders = orders,
                TotalOrdersCount = totalOrders
            };
        }

        public async Task<string> CreateOrderAsync(PaymentCheckoutPostModel model, CartIndexGetModel productsInCart, string userId)
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
                    Title = product.Title,
                    ImageUrl = product.ImageURL,
                    Quantity = product.QuantityToOrder,
                    Price = product.Price,
                    CurrencyId = product.Currency.Id
                });
            }

            string orderNumber = GenerateOrderNumber(await GetLastOrderNumberAsync());

            Order order = new Order()
            {
                OrderNumber = orderNumber,
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

            return orderNumber;
        }

        public string GenerateOrderNumber(int lastOrderNumber)
        {
            lastOrderNumber++;
            return "PO" + lastOrderNumber.ToString("D6");
        }

        public async Task<int> GetLastOrderNumberAsync()
        {
            return await _repository.AllReadOnly<Order>()
                .OrderByDescending(o => o.OrderNumber)
                .Select(o => int.Parse(o.OrderNumber.Substring(2)))
                .Take(1)
                .FirstOrDefaultAsync();
        }
    }
}
