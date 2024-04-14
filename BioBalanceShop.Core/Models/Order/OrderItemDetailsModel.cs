using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Order
{
    public class OrderItemDetailsModel
    {
        /// <summary>
        /// Order item identificator
        /// </summary>
        [Comment("Order item identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Order item name
        /// </summary>
        [Comment("Order item name")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Order item image URL
        /// </summary>
        [Comment("Order item image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Order item quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Order item price
        /// </summary>
        [Comment("Order item price")]
        public decimal Price { get; set; }
    }
}