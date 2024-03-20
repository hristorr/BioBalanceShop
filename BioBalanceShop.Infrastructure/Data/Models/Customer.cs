using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.Customer;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Customer data entity
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Customer identificator
        /// </summary>
        [Key]
        [Comment("Customer identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if customer exists
        /// </summary>
        [Required]
        [Comment("Indicator if customer exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Cusotmer first name
        /// </summary>
        [MaxLength(NameMaxLength)]
        [Comment("Customer first name")]
        public string? FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Cusotmer last name
        /// </summary>
        [MaxLength(NameMaxLength)]
        [Comment("Customer last name")]
        public string? LastName { get; set; } = string.Empty;

        /// <summary>
        /// User identificator
        /// </summary>
        [Required]
        [Comment("User identificator")]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// User
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        /// <summary>
        /// Customer address identificator
        /// </summary>
        [Comment("Customer address identificator")]
        public int? AddressId { get; set; }

        /// <summary>
        /// Shop identificator
        /// </summary>
        [Required]
        [Comment("Shop identificator")]
        public int ShopId { get; set; }

        /// <summary>
        /// Customer address
        /// </summary>
        [ForeignKey(nameof(AddressId))]
        public CustomerAddress? Address { get; set; } = null!;

        /// <summary>
        /// Shop
        /// </summary>
        [ForeignKey(nameof(ShopId))]
        public Shop Shop { get; set; } = null!;

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}