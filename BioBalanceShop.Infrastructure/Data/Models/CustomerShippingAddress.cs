using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.Address;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Customer shipping address data entity
    /// </summary>
    public class CustomerShippingAddress
    {
        /// <summary>
        /// Customer shipping address identificator
        /// </summary>
        [Key]
        [Comment("Customer shipping address identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if customer shipping address exists
        /// </summary>
        [Required]
        [Comment("Indicator if customer shipping address exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Customer shipping address street name
        /// </summary>
        [Required]
        [MaxLength(StreetMaxLength)]
        [Comment("Customer shipping address street name")]
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Customer shipping address post code
        /// </summary>
        [Required]
        [MaxLength(PostCodeMaxLength)]
        [Comment("Customer shipping address post code")]
        public string PostCode { get; set; } = string.Empty;

        /// <summary>
        /// Customer shipping address city
        /// </summary>
        [Required]
        [MaxLength(CityMaxLength)]
        [Comment("Customer shipping address city")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Customer shipping address country identificator
        /// </summary>
        [Required]
        [Comment("Customer shipping address country identificator")]
        public int CountryId { get; set; }

        /// <summary>
        /// Customer shipping address country
        /// </summary>
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; } = null!;
    }
}