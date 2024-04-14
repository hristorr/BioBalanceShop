using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Admin.Order;
using BioBalanceShop.Core.Models.Order;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Contracts
{
    public interface IAdminOrderService
    {
        Task<AdminOrderQueryServiceModel> AllAsync(
            OrderStatus? orderStatus = null,
            string? searchTerm = null,
            OrderSorting sorting = OrderSorting.OrderDateDescending,
            int currentPage = 1,
            int ordersPerPage = 1);

        Task<AdminOrderDetailsServiceModel?> GetOrderByIdAsync(int id);

        Task<IEnumerable<AdminOrderItemDetailsModel>> GetOrderItemsByOrderIdAsync(int id);

        Task UpdateOrderStatus(int orderId, OrderStatus status);
    }
}
