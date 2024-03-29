using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;

        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.AllReadOnly<Product>()
                .AnyAsync(h => h.Id == id);
        }

        public async Task<ProductQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, ProductSorting sorting = ProductSorting.Newest, int currentPage = 1, int productsPerPage = 1)
        {
            var productsToShow = _repository.AllReadOnly<Product>();

            if (category != null)
            {
                productsToShow = productsToShow
                    .Where(h => h.Category.Name == category);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                productsToShow = productsToShow
                    .Where(p => (p.Title.ToLower().Contains(normalizedSearchTerm) ||
                                p.Subtitle.ToLower().Contains(normalizedSearchTerm) ||
                                p.Description.ToLower().Contains(normalizedSearchTerm) ||
                                p.Ingredients.ToLower().Contains(normalizedSearchTerm)));
            }

            productsToShow = sorting switch
            {
                ProductSorting.PriceAscending => productsToShow
                    .OrderBy(p => p.TotalPrice),
                ProductSorting.PriceDescending => productsToShow
                    .OrderByDescending(p => p.TotalPrice),
                _ => productsToShow
                    .OrderByDescending(h => h.Id)
            };

            var products = await productsToShow
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ProjectToProductServiceModel()
                .ToListAsync();

            int totalProducts = await productsToShow.CountAsync();

            return new ProductQueryServiceModel()
            {
                Products = products,
                TotalProductsCount = totalProducts
            };
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await _repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<IEnumerable<ProductCategoryServiceModel>> AllCategoriesAsync()
        {
            return await _repository.AllReadOnly<Category>()
               .Select(c => new ProductCategoryServiceModel()
               {
                   Id = c.Id,
                   Name = c.Name,
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            return await _repository.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<ProductDetailsServiceModel?> GetProductByIdAsync(int id)
        {
            return await _repository
                .AllReadOnly<Product>()
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsServiceModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Subtitle = p.Subtitle,
                    Description = p.Description,
                    Ingredients = p.Ingredients,
                    ImageFrontUrl = p.ImageFrontUrl,
                    ImageBackUrl = p.ImageBackUrl,
                    Price = p.TotalPrice,
                    CurrencySymbol = p.Shop.Currency.Symbol,
                    CurrencyIsSymbolPrefix = p.Shop.Currency.IsSymbolPrefix
                })
                .FirstOrDefaultAsync();
        }
    }
}
