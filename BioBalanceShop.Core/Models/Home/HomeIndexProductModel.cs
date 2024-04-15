using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Home
{
    public class HomeIndexProductModel
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Subtitle")]
        public string Subtitle { get; set; } = string.Empty;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
