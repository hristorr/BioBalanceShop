using BioBalanceShop.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Order
{
    public class OrderQueryServiceModel
    {
        public int TotalOrdersCount { get; set; }

        public IEnumerable<OrderServiceModel> Orders { get; set; } = new List<OrderServiceModel>();
    }
}
