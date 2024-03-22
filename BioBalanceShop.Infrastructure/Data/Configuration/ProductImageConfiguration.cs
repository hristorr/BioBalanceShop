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
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new List<List<ProductImage>> {
                data.GreenNourishCompleteImages,
                data.MaxNourishImages,
                data.AcaiImmunoDefenceImages,
                data.AppleCiderVinegarComplexImages,
                data.WheyNourishChocolateFlavourImages,
                data.PeaNourishImages,
                data.ProBioMaxImages,
                data.NaturaCImages,
                data.MealTimeVanillaFlavourImages,
                data.FibreAndFullImages
            });
        }
    }
}
