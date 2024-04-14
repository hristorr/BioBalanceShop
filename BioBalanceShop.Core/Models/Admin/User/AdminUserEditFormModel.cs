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
    public class AdminUserEditFormModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Username")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Role")]
        public string Role { get; set; } = string.Empty;

        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}
