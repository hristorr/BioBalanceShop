using BioBalanceShop.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Admin.Order
{
    public class AdminOrderQueryServiceModel
    {
        public int TotalOrdersCount { get; set; }

        public IEnumerable<AdminOrderAllServiceModel> Orders { get; set; } = new List<AdminOrderAllServiceModel>();
    }
}
