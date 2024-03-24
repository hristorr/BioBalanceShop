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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasQueryFilter(c => c.IsActive);

            builder.HasOne(c => c.Shop)
                .WithMany(s => s.Customers)
                .HasForeignKey(c => c.ShopId)
                .OnDelete(DeleteBehavior.Restrict);

            //var data = new SeedData();

            //builder.HasData(new Customer[] {
            //    data.IvanIvanovCustomer
            //});
        }
    }
}
