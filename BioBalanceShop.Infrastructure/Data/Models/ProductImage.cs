using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Product image data entity
    /// </summary>
    public class ProductImage
    {
        /// <summary>
        /// Product image identificator
        /// </summary>
        [Key]
        [Comment("Product image identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if product image exists
        /// </summary>
        [Required]
        [Comment("Indicator if product image exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Product image
        /// </summary>
        [Required]
        [Comment("Product image")]
        public byte[] Image { get; set; } = null!;

        /// <summary>
        /// Product identificator
        /// </summary>
        [Required]
        [Comment("Product identificator")]
        public int ProductId { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
