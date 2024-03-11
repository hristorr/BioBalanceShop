using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Infrastructure.Data.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasQueryFilter(c => c.IsActive);

            builder.HasOne(c => c.Shop)
                .WithMany(s => s.ShipToCountries)
                .HasForeignKey(c => c.ShopId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
