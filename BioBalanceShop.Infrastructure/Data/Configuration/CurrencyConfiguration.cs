using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Infrastructure.Data.Configuration
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasQueryFilter(c => c.IsActive);

            //var data = new SeedData();

            //builder.HasData(new Currency[] {
            //    data.BgnCurrency,
            //    data.EurCurrency,
            //    data.UsdCurrency,
            //    data.GbpCurrency
            //});
        }
    }
}
