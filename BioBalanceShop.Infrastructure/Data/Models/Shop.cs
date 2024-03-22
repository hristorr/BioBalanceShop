using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BioBalanceShop.Infrastructure.Constants.DataConstants;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Shop data entity
    /// </summary>
    public class Shop
    {
        /// <summary>
        /// Shop identificator
        /// </summary>
        [Key]
        [Comment("Shop identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if shop exists
        /// </summary>
        [Required]
        [Comment("Indicator if shop exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Shop currency
        /// </summary>
        [Required]
        [Comment("Shop currency identificator")]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Tax rate applied to shop products
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Tax rate applied to shop products")]
        public decimal? TaxRate { get; set; }

        /// <summary>
        /// Discount rate applied to shop products
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Discount rate applied to shop products")]
        public decimal? DiscountRate { get; set; }

        /// <summary>
        /// Shipping fee rate applied to products in cart
        /// </summary>
        [Comment("Shipping fee rate applied to products in cart")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ShippingFeeRate { get; set; }

        /// <summary>
        /// Shop currency
        /// </summary>
        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; set; } = null!;

        /// <summary>
        /// Products
        /// </summary>
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Customers
        /// </summary>
        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
    }
}