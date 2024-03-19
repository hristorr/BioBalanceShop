using BioBalanceShop.Infrastructure.Data.Configuration;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BioBalanceShop.Infrastructure.Data
{
    public class BioBalanceDbContext : IdentityDbContext<IdentityUser>
    {
        public BioBalanceDbContext(DbContextOptions<BioBalanceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerBillingAddress> CustomerBillingAddresses { get; set; }
        public DbSet<CustomerShippingAddress> CustomerShippingAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBillingAddress> OrderBillingAddresses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderShippingAddress> OrderShippingAddresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new CustomerBillingAddressConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new CustomerShippingAddressConfiguration());
            builder.ApplyConfiguration(new OrderBillingAddressConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new OrderShippingAddressConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ShopConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
