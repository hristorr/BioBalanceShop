using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BioBalanceShop.Infrastructure.Constants.DataConstants;
using BioBalanceShop.Infrastructure.Data.Models;

namespace BioBalanceShop.Infrastructure.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasQueryFilter(u => u.IsActive);

            var data = new SeedData();

            builder.HasData(new ApplicationUser[] {
                data.AdminUser,
                data.CustomerUser
            });
        }
    }
}
