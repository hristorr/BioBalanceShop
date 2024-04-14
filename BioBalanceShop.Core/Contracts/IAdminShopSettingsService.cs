using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Admin.ShopSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Contracts
{
    public interface IAdminShopSettingsService
    {
        Task<AdminShopSettingsFormModel> AllShopSettingsAsync();

        Task EditShopSettingsAsync(AdminShopSettingsFormModel model);

        Task<IEnumerable<ShopCurrencyServiceModel>> AllCurrenciesAsync();
    }
}
