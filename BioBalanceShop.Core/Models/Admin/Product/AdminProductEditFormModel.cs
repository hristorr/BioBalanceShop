using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.ProductData;
using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Product;

namespace BioBalanceShop.Core.Models.Admin.Product
{
    public class AdminProductEditFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductCodeMaxLength)]
        [Display(Name = "Product code")]
        public string ProductCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(SubtitleMaxLength)]
        public string Subtitle { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(IngredeientsMaxLength)]
        public string Ingredients { get; set; } = string.Empty;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Stock quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Unit price")]
        public decimal Price { get; set; }

        public ShopCurrencyServiceModel? Currency { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryAllServiceModel> Categories { get; set; } = new List<CategoryAllServiceModel>();
    }
}
