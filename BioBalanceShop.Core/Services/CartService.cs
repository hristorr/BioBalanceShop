using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Cart;
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
    public class CartService : ICartService
    {
        private readonly IRepository _repository;
        private readonly IProductService _productService;
        private readonly IShopService _shopService;

        public CartService(
            IRepository repository,
            IProductService productService,
            IShopService shopService)
        {
            _repository = repository;
            _productService = productService;
            _shopService = shopService;
        }

        public async Task<CartIndexGetModel> GetCartProductsInfo(CartCookieModel cart)
        {
            CartIndexGetModel productsInCart = new CartIndexGetModel();

            foreach (var item in cart.Items)
            {
                if (await _productService.ExistsAsync(item.ProductId))
                {
                    CartIndexGetProductModel product = await GetProductFromCart(item.ProductId, item.Quantity);
                    productsInCart.Items.Add(product);
                }
            }

            return productsInCart;
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
                   Currency = new CartIndexGetProductCurrencyModel()
                   {
                       Id = p.Shop.Currency.Id,
                       CurrencySymbol = p.Shop.Currency.Symbol,
                       CurrencyIsSymbolPrefix = p.Shop.Currency.IsSymbolPrefix
                   }
               })
               .FirstOrDefaultAsync();
        }

        public void UpdateProductsInCart(CartUpdateModel updateModel, CartCookieModel cart)
        {
            foreach (var kvp in updateModel.ProductQuantities)
            {
                CartItemCookieModel? itemToUpdate = cart.Items.FirstOrDefault(item => item.ProductId == kvp.Key);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Quantity = kvp.Value;
                }
            }

            foreach (int productId in updateModel.RemovedProductIds)
            {
                cart.Items.RemoveAll(item => item.ProductId == productId);
            }
        }
    }
}
