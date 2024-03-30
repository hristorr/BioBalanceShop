using BioBalanceShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Contracts
{
    public interface IShopService
    {
        Task<ShopCurrencyServiceModel?> GetShopCurrency();
    }
}
