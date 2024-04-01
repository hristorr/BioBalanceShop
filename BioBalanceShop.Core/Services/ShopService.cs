using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Services
{
    public class ShopService : IShopService
    {
        private readonly IRepository _repository;

        public ShopService(IRepository repository)
        {
            _repository = repository;

        }

        public async Task<decimal?> GetShippingFeeRate()
        {
            return await _repository.AllReadOnly<Shop>()
                .Select(s => s.ShippingFeeRate)
                .FirstOrDefaultAsync();
        }

        public async Task<ShopCurrencyServiceModel?> GetShopCurrency()
        {
            return await _repository.AllReadOnly<Shop>()
                .Select(s => new ShopCurrencyServiceModel()
                {
                    CurrencyCode = s.Currency.Code,
                    CurrencySymbol = s.Currency.Symbol,
                    CurrencyIsSymbolPrefix = s.Currency.IsSymbolPrefix
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ShopCountryServiceModel>> AllCountriesAsync()
        {
            return await _repository.AllReadOnly<Country>()
               .Select(c => new ShopCountryServiceModel()
               {
                   Id = c.Id,
                   Name = c.Name,
               })
               .ToListAsync();
        }
    }
}
