﻿using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Core.Models.Order;
using BioBalanceShop.Core.Models.Payment;
using BioBalanceShop.Core.Models.Product;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Contracts
{
    public interface IOrderService
    {
        Task<string> CreateOrderAsync(PaymentCheckoutPostModel model, CartIndexGetModel productsInCart, string userId);

        string GenerateOrderNumber(int lastOrderNumber);

        Task<int> GetLastOrderNumberAsync();

        Task<OrderQueryServiceModel> AllAsync(
            OrderStatus? orderStatus = null,
            string? searchTerm = null,
            OrderSorting sorting = OrderSorting.OrderDateDescending,
            int currentPage = 1,
            int ordersPerPage = 1, 
            string? userId = null);
    }
}
