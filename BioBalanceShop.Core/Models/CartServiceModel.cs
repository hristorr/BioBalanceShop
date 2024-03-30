using Microsoft.AspNetCore.Http.Features;

namespace BioBalanceShop.Models
{
    public class CartServiceModel
    {
        public List<CartItemServiceModel> Items { get; set; } = new List<CartItemServiceModel>();

        public decimal TotalPrice { get; set; }

        public string CurrencySymbol { get; set; } = string.Empty;

        public bool CurrencyIsSymbolPrefix { get; set; }
    }
}
