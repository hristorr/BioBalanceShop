using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.ApplicationUserData;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// ApplicationUser extension data entity
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// User first name
        /// </summary>
        [MaxLength(NameMaxLength)]
        [PersonalData]
        [Comment("User first name")]
        public string? FirstName { get; set; } = string.Empty;

        /// <summary>
        /// User last name
        /// </summary>
        [MaxLength(NameMaxLength)]
        [PersonalData]
        [Comment("User last name")]
        public string? LastName { get; set; } = string.Empty;
    }
}
