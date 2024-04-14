using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BioBalanceShop.Core.Constants.MessageConstants;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.ApplicationUserData;

namespace BioBalanceShop.Core.Models.Admin.User
{
    public class UserCreateFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(EmailMaxLength,
            MinimumLength = EmailMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Username")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(EmailMaxLength,
            MinimumLength = EmailMinLength,
            ErrorMessage = LengthMessage)]
        [RegularExpression(EmailRegexPattern,
            ErrorMessage = EmailFormatErrorMessage)]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PasswordMaxLength,
            MinimumLength = PasswordMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = PasswordConfirmErrorMessage)]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [StringLength(PhoneMaxLength,
           MinimumLength = PhoneMinLength,
           ErrorMessage = LengthMessage)]
        [RegularExpression(PhoneRegexPattern,
           ErrorMessage = FormatErrorMessage)]
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Role")]
        public string Role { get; set; } = string.Empty;

        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}
