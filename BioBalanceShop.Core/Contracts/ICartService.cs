using BioBalanceShop.Core.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Contracts
{
    public interface ICartService
    {
        Task<CartIndexGetModel> GetCartProductsInfo(CartCookieModel cart);
        Task<CartIndexGetProductModel?> GetProductFromCart(int id, int quantity);
        void UpdateProductsInCart(CartUpdateModel updateModel, CartCookieModel cart);
    }
}
