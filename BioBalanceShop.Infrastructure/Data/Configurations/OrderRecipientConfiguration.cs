using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Infrastructure.Data.Configurations
{
    public class OrderRecipientConfiguration : IEntityTypeConfiguration<OrderRecipient>
    {
        public void Configure(EntityTypeBuilder<OrderRecipient> builder)
        {
            builder.HasQueryFilter(or => or.IsActive);

            var data = new SeedData();

            builder.HasData(new OrderRecipient[] {
                data.IvanIvanovOrderRecipient
            });
        }
    }
}
