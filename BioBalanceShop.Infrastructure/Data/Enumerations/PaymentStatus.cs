using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Infrastructure.Data.Enumerations
{
    public enum PaymentStatus
    {
        Success = 1,
        Failed = 2,
        Cancelled = 3,
        Credited = 4
    }
}
