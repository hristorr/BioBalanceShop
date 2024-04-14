using BioBalanceShop.Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Customer
{
    public class CustomerAddressFormModel
    {
        [Display(Name = "Street")]
        public string? Street { get; set; } = string.Empty;

        [Display(Name = "Post code")]
        public string? PostCode { get; set; } = string.Empty;

        [Display(Name = "City")]
        public string? City { get; set; } = string.Empty;

        [Display(Name = "Country")]
        public CustomerAddressCountryFormModel? Country { get; set; } = null!;

        public IList<ShopCountryServiceModel> Countries { get; set; } = new List<ShopCountryServiceModel>();
    }
}
