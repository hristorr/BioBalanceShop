using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Infrastructure.Data.Enumerations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Admin.Order
{
    public class AdminOrderServiceModel
    {
        /// <summary>
        /// Order identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order number
        /// </summary>
        public string OrderNumber { get; set; } = string.Empty;

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
        /// Order total amount including shipping fee
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Order total amount including shipping fee")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Order currency
        /// </summary>
        public ShopCurrencyServiceModel Currency { get; set; } = null!;

        /// <summary>
        /// Order items count
        /// </summary>
        public int OrderItemsCount { get; set; }
    }
}
