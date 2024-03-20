using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Infrastructure.Data.Enumerations
{
    public enum OrderStatus
    {
        Paid = 1,
        Processing = 2,
        Shipped = 3,
        Delivered = 4
    }
}
