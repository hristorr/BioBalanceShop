using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models
{
    public class CheckoutServiceModel
    {
        public CheckoutCustomerServiceModel Customer { get; set; }
        public CheckoutOrderServiceModel Order { get; set; }
    }
}
