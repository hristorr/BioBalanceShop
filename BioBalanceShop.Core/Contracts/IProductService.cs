using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models;
using BioBalanceShop.Models;
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

        Task<IEnumerable<ProductCategoryServiceModel>> AllCategoriesAsync();
        
        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<ProductDetailsServiceModel?> GetProductByIdAsync(int id);

        Task<CartItemServiceModel?> GetProductFromCart(int id, int quantity);
    }
}
