using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Admin.Order
{
    public class AdminOrderItemDetailsModel
    {
        /// <summary>
        /// Order item identificator
        /// </summary>
        [Comment("Order item identificator")]
        public int? Id { get; set; }

        /// <summary>
        /// Order item name
        /// </summary>
        [Comment("Order item name")]
        public string? Title { get; set; } = string.Empty;

        /// <summary>
        /// Order item image URL
        /// </summary>
        [Comment("Order item image URL")]
        public string? ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Order item quantity
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Order item price
        /// </summary>
        [Comment("Order item price")]
        public decimal? Price { get; set; }
    }
}
