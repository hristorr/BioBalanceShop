using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// Customer shipping address identificator
        /// </summary>
        [Required]
        [Comment("Customer shipping address identificator")]
        public int CustomerShippingAddressId { get; set; }

        /// <summary>
        /// Customer billing address identificator
        /// </summary>
        [Required]
        [Comment("Customer billing address identificator")]
        public int CustomerBillingAddressId { get; set; }

        /// <summary>
        /// Customer shipping address
        /// </summary>
        [ForeignKey(nameof(CustomerShippingAddressId))]
        public CustomerShippingAddress CustomerShippingAddress { get; set; } = null!;

        /// <summary>
        /// Customer billing address
        /// </summary>
        [ForeignKey(nameof(CustomerBillingAddressId))]
        public CustomerBillingAddress CustomerBillingAddress { get; set; } = null!;

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}