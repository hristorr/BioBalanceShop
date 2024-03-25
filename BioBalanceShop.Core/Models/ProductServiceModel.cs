using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models
{
    public class ProductServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}