using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models
{
    public class ShopCurrencyServiceModel
    {
        public string CurrencySymbol { get; set; } = string.Empty;

        public bool CurrencyIsSymbolPrefix { get; set; }
    }
}
