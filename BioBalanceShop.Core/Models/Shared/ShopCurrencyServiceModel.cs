using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models._Base
{
    public class ShopCurrencyServiceModel
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;

        public string CurrencySymbol { get; set; } = string.Empty;

        public bool CurrencyIsSymbolPrefix { get; set; }
    }
}
