using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Payment
{
    public class PaymentCheckoutGetModel
    {
        public PaymentCheckoutGetCustomerModel Customer { get; set; }
        public PaymentCheckoutGetOrderModel Order { get; set; }
    }
}
