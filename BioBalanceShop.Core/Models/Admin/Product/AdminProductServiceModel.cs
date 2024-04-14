using BioBalanceShop.Core.Models._Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Admin.Product
{
    public class AdminProductServiceModel
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Product code")]
        public string ProductCode { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Stock quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Unit price")]
        public decimal Price { get; set; }

        public ShopCurrencyServiceModel Currency { get; set; } = null!;
    }
}
