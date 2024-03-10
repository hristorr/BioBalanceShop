using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.Address;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Order shipping address data entity
    /// </summary>
    public class OrderShippingAddress
    {
        /// <summary>
        /// Order shipping address identificator
        /// </summary>
        [Key]
        [Comment("Order shipping address identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if order shipping address exists
        /// </summary>
        [Required]
        [Comment("Indicator if order shipping address exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Order shipping address street name
        /// </summary>
        [Required]
        [MaxLength(StreetMaxLength)]
        [Comment("Order shipping address street name")]
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Order shipping address post code
        /// </summary>
        [Required]
        [MaxLength(PostCodeMaxLength)]
        [Comment("Order shipping address post code")]
        public string PostCode { get; set; } = string.Empty;

        /// <summary>
        /// Order shipping address city
        /// </summary>
        [Required]
        [MaxLength(CityMaxLength)]
        [Comment("Order shipping address city")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Order shipping address country identificator
        /// </summary>
        [Required]
        [Comment("Order shipping address country identificator")]
        public int CountryId { get; set; }

        /// <summary>
        /// Order shipping address country
        /// </summary>
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; } = null!;
    }
}