using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Customer
{
    public class CustomerAddressCountryFormModel
    {
        public int? Id { get; set; }

        [Display(Name = "Country")]
        [PersonalData]
        public string? Name { get; set; } = string.Empty;
    }
}
