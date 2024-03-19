﻿using Microsoft.AspNetCore.Http;
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
        public int OrderNumber { get; set; }

        /// <summary>
        /// Order date
        /// </summary>
        [Required]
        [Comment("Order date")]
        public int OrderDate { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        [Required]
        [MaxLength(StatusMaxLength)]
        [Comment("Order status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Order net price
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Order net price")]
        public decimal NetPrice { get; set; }

        /// <summary>
        /// Order shipping fee
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Order shipping fee")]
        public decimal? ShippingFee { get; set; }

        /// <summary>
        /// Discount amount on order level
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Discount amount on order level")]
        public decimal? DiscountAmount { get; set; }

        /// <summary>
        /// Taxable amount including discount and shipping fees
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Taxable amount including discount and shipping fees")]
        public decimal TaxableAmount { get; set; }

        /// <summary>
        /// Tax amount on order level
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Tax amount on order level")]
        public decimal? TaxAmount { get; set; }

        /// <summary>
        /// Order total price with tax
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Order total price with tax")]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Order currency code
        /// </summary>
        [Required]
        [MaxLength(CurrencyCodeMaxLength)]
        [RegularExpression(CurrencyCodeRegexPattern)]
        [Comment("Order currency code")]
        public string CurrencyCode { get; set; } = string.Empty;

        /// <summary>
        /// Customer identificator
        /// </summary>
        [Required]
        [Comment("Customer identificator")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Order shipping address identificator
        /// </summary>
        [Required]
        [Comment("Order shipping address identificator")]
        public int OrderShippingAddressId { get; set; }

        /// <summary>
        /// Order billing address identificator
        /// </summary>
        [Required]
        [Comment("Order billing address identificator")]
        public int OrderBillingAddressId { get; set; }

        /// <summary>
        /// Customer
        /// </summary>
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        /// <summary>
        /// Order shipping address
        /// </summary>
        [ForeignKey(nameof(OrderShippingAddressId))]
        public OrderShippingAddress OrderShippingAddress { get; set; } = null!;

        /// <summary>
        /// Order billing address
        /// </summary>
        [ForeignKey(nameof(OrderBillingAddressId))]
        public OrderBillingAddress OrderBillingAddress { get; set; } = null!;

        /// <summary>
        /// Order items
        /// </summary>
        public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}