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
    public class CustomerShippingAddressConfiguration : IEntityTypeConfiguration<CustomerShippingAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerShippingAddress> builder)
        {
            builder.HasQueryFilter(csa => csa.IsActive);

            builder.HasOne(csa => csa.Country)
                .WithMany(c => c.CustomerShippingAddresses)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
