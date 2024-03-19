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

            //builder.HasMany(c => c.CustomerBillingAddresseses)
            //    .WithOne(cba => cba.Country)
            //    .HasForeignKey(cba => cba.CountryId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(c => c.CustomerShippingAddresses)
            //    .WithOne(csa => csa.Country)
            //    .HasForeignKey(csa => csa.CountryId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(c => c.OrderBillingAddresseses)
            //    .WithOne(oba => oba.Country)
            //    .HasForeignKey(oba => oba.CountryId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(c => c.OrderShippingAddresses)
            //    .WithOne(osa => osa.Country)
            //    .HasForeignKey(osa => osa.CountryId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
