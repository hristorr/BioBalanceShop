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
    public class OrderService : IOrderService
    {
        private readonly IRepository _repository;

        public OrderService(IRepository repository)
        {
            _repository = repository;

        }
        public string GenerateOrderNumber(int lastOrderNumber)
        {
            lastOrderNumber++;
            return "PO" + lastOrderNumber.ToString("D6");
        }

        public async Task<int> GetLastOrderNumberAsync()
        {
            return await _repository.AllReadOnly<Order>()
                .Select(o => new
                {
                    PoNumber = int.Parse(o.OrderNumber.Substring(2))
                })
                .OrderByDescending(o => o.PoNumber)
                .Take(1)
                .Select(o => o.PoNumber)
                .FirstOrDefaultAsync();
        }
    }
}
