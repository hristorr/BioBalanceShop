using BioBalanceShop.Infrastructure.Data.Enumerations;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBalanceShop.Core.Models._Base;

namespace BioBalanceShop.Core.Models.Order
{
    public class OrderDetailsServiceModel
    {
        /// <summary>
        /// Order identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order number
        /// </summary>
        [Comment("Order number")]
        public string OrderNumber { get; set; } = string.Empty;

        /// <summary>
        /// Order date
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Order amount excluding shipping fee
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Order shipping fee
        /// </summary>
        public decimal ShippingFee { get; set; }

        /// <summary>
        /// Order total amount including shipping fee
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Order currency
        /// </summary>
        public ShopCurrencyServiceModel Currency { get; set; } = null!;

        /// <summary>
        /// Order address
        /// </summary>
        public OrderAddressDetailsModel OrderAddress { get; set; } = null!;

        /// <summary>
        /// Order recipient
        /// </summary>
        public OrderRecipientDetailsModel OrderRecipient { get; set; } = null!;

        /// <summary>
        /// Order items
        /// </summary>
        public IEnumerable<OrderItemDetailsModel> OrderItems { get; set; } = new List<OrderItemDetailsModel>();
    }
}
