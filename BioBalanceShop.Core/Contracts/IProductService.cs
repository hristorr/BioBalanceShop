using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Core.Models.Home;
using BioBalanceShop.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Contracts
{
    public interface IProductService
    {
        Task<bool> ExistsAsync(int id);

        Task<ProductQueryServiceModel> AllAsync(
           string? category = null,
           string? searchTerm = null,
           ProductSorting sorting = ProductSorting.Newest,
           int currentPage = 1,
           int productsPerPage = 1);

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<IEnumerable<CategoryAllServiceModel>> AllCategoriesAsync();
        
        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<ProductDetailsServiceModel?> GetProductByIdAsync(int id);

        Task<IEnumerable<HomeIndexGetProductModel>> GetLastFiveProductsAsync();
    }
}
