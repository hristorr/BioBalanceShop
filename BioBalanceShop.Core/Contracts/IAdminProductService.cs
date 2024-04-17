using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Admin.Product;
using BioBalanceShop.Core.Models.Admin.User;
using BioBalanceShop.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Contracts
{
    public interface IAdminProductService
    {
        Task<AdminProductQueryServiceModel> AllAsync(
           string? category = null,
           string? searchTerm = null,
           AdminProductSorting sorting = AdminProductSorting.Newest,
           int currentPage = 1,
           int productsPerPage = 1);

        Task DeleteProductByIdAsync(int productId);

        Task EditProductAsync(AdminProductEditFormModel model);

        Task<AdminProductEditFormModel?> GetProductByIdAsync(int id);

        Task CreateProductAsync(AdminProductCreateFormModel model, string userId);

        Task<bool> ProductCodeExistsAsync(string productCode);

        Task<bool> ProductCodeExistsAsync(string productCode, int productId);
    }
}
