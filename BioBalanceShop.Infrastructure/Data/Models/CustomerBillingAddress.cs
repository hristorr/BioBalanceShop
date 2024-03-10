using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.Address;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Customer billing address data entity
    /// </summary>
    public class CustomerBillingAddress
    {
        /// <summary>
        /// Customer billing address identificator
        /// </summary>
        [Key]
        [Comment("Customer billing address identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if customer billing address exists
        /// </summary>
        [Required]
        [Comment("Indicator if customer billing address exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Customer billing address street name
        /// </summary>
        [Required]
        [MaxLength(StreetMaxLength)]
        [Comment("Customer billing address street name")]
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Customer billing address post code
        /// </summary>
        [Required]
        [MaxLength(PostCodeMaxLength)]
        [Comment("Customer billing address post code")]
        public string PostCode { get; set; } = string.Empty;

        /// <summary>
        /// Customer billing address city
        /// </summary>
        [Required]
        [MaxLength(CityMaxLength)]
        [Comment("Customer billing address city")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Customer billing address country identificator
        /// </summary>
        [Required]
        [Comment("Customer billing address country identificator")]
        public int CountryId { get; set; }

        /// <summary>
        /// Customer billing address country
        /// </summary>
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; } = null!;
    }
}