using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Core.Models.Home;
using BioBalanceShop.Core.Models.Product;
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
            var productsToShow = _repository.AllReadOnly<Product>()
                .Where(p => p.Quantity > 0);

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
                    .OrderBy(p => p.Price),
                ProductSorting.PriceDescending => productsToShow
                    .OrderByDescending(p => p.Price),
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

        public async Task<IEnumerable<ProductAllGetCategoryModel>> AllCategoriesAsync()
        {
            return await _repository.AllReadOnly<Category>()
               .Select(c => new ProductAllGetCategoryModel()
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

        public async Task<ProductDetailsGetModel?> GetProductByIdAsync(int id)
        {
            return await _repository
                .AllReadOnly<Product>()
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsGetModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Subtitle = p.Subtitle,
                    Description = p.Description,
                    Ingredients = p.Ingredients,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    QuantityToOrder = 1,
                    QuantityInStock = p.Quantity,
                    CurrencySymbol = p.Shop.Currency.Symbol,
                    CurrencyIsSymbolPrefix = p.Shop.Currency.IsSymbolPrefix
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CartIndexGetProductModel?> GetProductFromCart(int id, int quantity)
        {
            return await _repository
               .AllReadOnly<Product>()
               .Where(p => p.Id == id)
               .Select(p => new CartIndexGetProductModel()
               {
                   ProductId = p.Id,
                   Title = p.Title,
                   ImageURL = p.ImageUrl,
                   QuantityToOrder = quantity,
                   QuantityInStock = p.Quantity,
                   Price = p.Price,
                   CurrencySymbol = p.Shop.Currency.Symbol,
                   CurrencyIsSymbolPrefix = p.Shop.Currency.IsSymbolPrefix
               })
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<HomeIndexGetProductModel>> GetLastFiveProductsAsync()
        {
            return await _repository
                .AllReadOnly<Product>()
                .OrderByDescending(p => p.Id)
                .Take(5)
                .Select(p => new HomeIndexGetProductModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                })
                .ToListAsync();
        }
    }
}
