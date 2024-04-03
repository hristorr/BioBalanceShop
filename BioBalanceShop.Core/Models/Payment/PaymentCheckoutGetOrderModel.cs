using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Payment
{
    public class PaymentCheckoutGetOrderModel
    {
        public decimal OrderAmount { get; set; }

        [Display(Name = "Shipping Fee")]
        public decimal ShippingFee { get; set; }

        [Display(Name = "Total Order Amount")]
        public decimal TotalOrderAmount => OrderAmount + ShippingFee;

        public string CurrencyCode { get; set; } = string.Empty;

        public string CurrencySymbol { get; set; } = string.Empty;

        public bool CurrencyIsSymbolPrefix { get; set; }
    }
}
