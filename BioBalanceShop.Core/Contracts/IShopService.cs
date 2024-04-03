using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Payment;
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

        Task<decimal?> GetShippingFeeRate();

        Task<IEnumerable<PaymentCheckoutGetCountryModel>> AllCountriesAsync();
    }
}
