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
    public class CustomerBillingAddressConfiguration : IEntityTypeConfiguration<CustomerBillingAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerBillingAddress> builder)
        {
            builder.HasQueryFilter(cba => cba.IsActive);

            builder.HasOne(cba => cba.Country)
                .WithMany(c => c.CustomerBillingAddresseses)
                .HasForeignKey(cba => cba.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
