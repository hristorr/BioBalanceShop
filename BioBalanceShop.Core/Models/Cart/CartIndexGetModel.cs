using Microsoft.AspNetCore.Http.Features;

namespace BioBalanceShop.Core.Models.Cart
{
    public class CartIndexGetModel
    {
        public List<CartIndexGetProductModel> Items { get; set; } = new List<CartIndexGetProductModel>();

        public decimal TotalPrice { get; set; }

        public string CurrencySymbol { get; set; } = string.Empty;

        public bool CurrencyIsSymbolPrefix { get; set; }
    }
}
