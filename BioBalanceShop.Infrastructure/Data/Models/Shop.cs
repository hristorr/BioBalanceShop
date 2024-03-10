using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BioBalanceShop.Infrastructure.Constants.DataConstants;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.Shop;

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
        /// Shop name
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Shop name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Shop logotype
        /// </summary>
        [Comment("Shop logotype")]
        public byte[]? Logotype { get; set; }

        /// <summary>
        /// Shop owner identificator
        /// </summary>
        [Required]
        [Comment("Shop owner identificator")]
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// Shop currency
        /// </summary>
        [Required]
        [MaxLength(CurrencyCodeMaxLength)]
        [RegularExpression(CurrencyCodeRegexPattern)]
        [Comment("Shop currency code")]
        public string CurrencyCode { get; set; } = string.Empty;

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
        /// Shop owner
        /// </summary>
        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;

        /// <summary>
        /// Shop users
        /// </summary>
        public IEnumerable<IdentityUser> Users { get; set; } = new List<IdentityUser>();

        /// <summary>
        /// Countries the shop ships to
        /// </summary>
        public IEnumerable<Country> ShipToCountries { get; set; } = new List<Country>();

        /// <summary>
        /// Shop products
        /// </summary>
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Shop orders
        /// </summary>
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}