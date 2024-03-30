using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models
{
    public class ProductDetailsServiceModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Subtitle { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Ingredients { get; set; } = string.Empty;

        [Required]
        public string ImageFrontUrl { get; set; } = string.Empty;

        public string? ImageBackUrl { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int QuantityToOrder { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public string CurrencySymbol { get; set; } = string.Empty;

        [Required]
        public bool CurrencyIsSymbolPrefix { get; set; }
    }
}
