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
    public class OrderShippingAddressConfiguration : IEntityTypeConfiguration<OrderShippingAddress>
    {
        public void Configure(EntityTypeBuilder<OrderShippingAddress> builder)
        {
            builder.HasQueryFilter(osa => osa.IsActive);

            builder.HasOne(osa => osa.Country)
                .WithMany(c => c.OrderShippingAddresses)
                .HasForeignKey(osa => osa.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
