using BioBalanceShop.Core.Models.Product;
using BioBalanceShop.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class IQueryableProductExtension
    {
        public static IQueryable<ProductServiceModel> ProjectToProductServiceModel(this IQueryable<Product> products)
        {
            return products
                .Select(h => new ProductServiceModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl,
                    Price = h.Price,
                });
        }
    }
}
