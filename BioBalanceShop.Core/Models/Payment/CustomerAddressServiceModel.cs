using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBalanceShop.Core.Models.Shared;

namespace BioBalanceShop.Core.Models.Payment
{
    public class CustomerAddressServiceModel
    {
        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Post code")]
        public string PostCode { get; set; } = string.Empty;

        [Required]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Country")]

        public ShopCountryServiceModel Country { get; set; } = null!;
    }
}
