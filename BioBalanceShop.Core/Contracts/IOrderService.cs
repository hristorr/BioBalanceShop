using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Core.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Contracts
{
    public interface IOrderService
    {
        Task CreateOrderAsync(PaymentCheckoutPostModel model, CartIndexGetModel productsInCart, string userId);
    }
}
