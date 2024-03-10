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
    public class OrderBillingAddressConfiguration : IEntityTypeConfiguration<OrderBillingAddress>
    {
        public void Configure(EntityTypeBuilder<OrderBillingAddress> builder)
        {
            builder.HasQueryFilter(oba => oba.IsActive);

            builder.HasOne(cba => cba.Country)
                .WithMany(c => c.OrderBillingAddresseses)
                .HasForeignKey(cba => cba.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
