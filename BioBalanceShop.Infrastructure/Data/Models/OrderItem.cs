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
        /// Order item quantity
        /// </summary>
        [Required]
        [Comment("Order item quantity")]
        public int Quantity { get; set; }
        
        /// <summary>
        /// Order item price
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Order item price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Order item currency identificator
        /// </summary>
        [Required]
        [Comment("Order item currency identificator")]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Order item product identificator
        /// </summary>
        [Required]
        [Comment("Order item product identificator")]
        public int ProductId { get; set; }

        /// <summary>
        /// Order item order identificator
        /// </summary>
        [Required]
        [Comment("Order item order identificator")]
        public int OrderId { get; set; }

        /// <summary>
        /// Order item currency
        /// </summary>
        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; set; } = null!;

        /// <summary>
        /// Order item product
        /// </summary>
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        /// <summary>
        /// Order item order
        /// </summary>
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;
    }
}