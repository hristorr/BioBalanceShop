using BioBalanceShop.Infrastructure.Data.Enumerations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BioBalanceShop.Infrastructure.Constants.DataConstants;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.Order;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Order data entity
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order identificator
        /// </summary>
        [Key]
        [Comment("Order identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if order exists
        /// </summary>
        [Required]
        [Comment("Indicator if order exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Order number
        /// </summary>
        [Required]
        [MaxLength(OrderNumberMaxLength)]
        [Comment("Order number")]
        public string OrderNumber => "PO" + new Random().Next(10, 100) + (char)(new Random().Next(101, 133)) + Id + new Random().Next(100, 1000);

        /// <summary>
        /// Order date
        /// </summary>
        [Required]
        [Comment("Order date")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        [Required]
        [EnumDataType(typeof(OrderStatus))]
        [Comment("Order status")]
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Order amount excluding shipping fee
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Order amount excluding shipping fee")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Order shipping fee
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Order shipping fee")]
        public decimal? ShippingFee { get; set; }

        /// <summary>
        /// Order total amount including shipping fee
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Order total amount including shipping fee")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Order currency identificator
        /// </summary>
        [Required]
        [Comment("Order currency identificator")]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Customer identificator
        /// </summary>
        [Required]
        [Comment("Customer identificator")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Order address identificator
        /// </summary>
        [Required]
        [Comment("Order address identificator")]
        public int OrderAddressId { get; set; }

        /// <summary>
        /// Payment identificator
        /// </summary>
        [Required]
        [Comment("Payment identificator")]
        public int PaymentId { get; set; }

        /// <summary>
        /// Order recipient identificator
        /// </summary>
        [Required]
        [Comment("Order recipient identificator")]
        public int OrderRecipientId { get; set; }

        /// <summary>
        /// Order currency
        /// </summary>
        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; set; } = null!;

        /// <summary>
        /// Customer
        /// </summary>
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        /// <summary>
        /// Order address
        /// </summary>
        [ForeignKey(nameof(OrderAddressId))]
        public OrderAddress OrderAddress { get; set; } = null!;

        /// <summary>
        /// Payment
        /// </summary>
        [ForeignKey(nameof(PaymentId))]
        public Payment Payment { get; set; } = null!;

        /// <summary>
        /// Order recipient
        /// </summary>
        [ForeignKey(nameof(OrderRecipientId))]
        public OrderRecipient OrderRecipient { get; set; } = null!;

        /// <summary>
        /// Order items
        /// </summary>
        public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}