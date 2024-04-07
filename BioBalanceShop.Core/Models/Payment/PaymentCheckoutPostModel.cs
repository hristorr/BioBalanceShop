using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Payment
{
    public class PaymentCheckoutPostModel
    {
        public PaymentCheckoutPostCustomerModel Customer { get; set; }
        public PaymentCheckoutPostOrderModel Order { get; set; }
    }
}
