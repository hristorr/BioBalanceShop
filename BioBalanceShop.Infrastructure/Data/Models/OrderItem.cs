using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.Product;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Order item data entity
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Order item identificator
        /// </summary>
        [Key]
        [Comment("Order item identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if order item exists
        /// </summary>
        [Required]
        [Comment("Indicator if order item exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Order item code
        /// </summary>
        [Required]
        [MaxLength(ProductCodeMaxLength)]
        [Comment("Order item product code")]
        public string ProductCode { get; set; } = string.Empty;

        /// <summary>
        /// Order item name
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Order item name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Order item description
        /// </summary>
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Order item description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Order item front image
        /// </summary>
        [Required]
        [Comment("Order item front image")]
        public byte[] ImageFront { get; set; } = null!;

        /// <summary>
        /// Order item back image
        /// </summary>
        [Comment("Order item back image")]
        public byte[]? ImageBack { get; set; }

        /// <summary>
        /// Order item quantity
        /// </summary>
        [Required]
        [Comment("Order item quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Order item price before discounts and taxes
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Order item price before discounts and taxes")]
        public decimal BasePrice { get; set; }

        /// <summary>
        /// Discount amount on order item level
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Discount amount on order item level")]
        public decimal? DiscountAmount { get; set; }

        /// <summary>
        /// Order item net price including discount before taxes
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Order item net price including discount before taxes")]
        public decimal PriceBeforeTax { get; set; }

        /// <summary>
        /// Tax rate on order item level
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Tax rate on order item level")]
        public decimal? TaxRate { get; set; }

        /// <summary>
        /// Tax amount on order item level
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Tax amount on order item level")]
        public decimal? TaxAmount { get; set; }

        /// <summary>
        /// Order item price including discounts and taxes
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Order item price including discounts and taxes")]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Order item category identificator
        /// </summary>
        [Required]
        [Comment("Order item category identificator")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Order item order identificator
        /// </summary>
        [Required]
        [Comment("Order item order identificator")]
        public int OrderId { get; set; }

        /// <summary>
        /// Order item category
        /// </summary>
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        /// <summary>
        /// Order item order
        /// </summary>
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;
    }
}