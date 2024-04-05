using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Contracts
{
    public interface IOrderService
    {
        Task<int> GetLastOrderNumberAsync();

        public string GenerateOrderNumber(int lastOrderNumber);
    }
}
