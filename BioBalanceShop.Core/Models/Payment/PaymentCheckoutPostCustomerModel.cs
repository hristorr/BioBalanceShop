using BioBalanceShop.Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.OrderRecipientData;
using static BioBalanceShop.Core.Constants.MessageConstants;

namespace BioBalanceShop.Core.Models.Payment
{
    public class PaymentCheckoutPostCustomerModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(PhoneMaxLength, 
            MinimumLength = PhoneMinLength, 
            ErrorMessage = LengthMessage)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

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

        public IList<ShopCountryServiceModel> Countries { get; set; } = new List<ShopCountryServiceModel>();
    }
}
