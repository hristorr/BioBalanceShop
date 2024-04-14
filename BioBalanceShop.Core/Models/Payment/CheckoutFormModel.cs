using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Payment
{
    public class CheckoutFormModel
    {
        public CheckoutCustomerFormModel Customer { get; set; }
        public CheckoutOrderFormModel Order { get; set; }
    }
}
