using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.Address;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Order billing address data entity
    /// </summary>
    public class OrderBillingAddress
    {
        /// <summary>
        /// Order billing address identificator
        /// </summary>
        [Key]
        [Comment("Order billing address identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if order billing address exists
        /// </summary>
        [Required]
        [Comment("Indicator if order billing address exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Order billing address street name
        /// </summary>
        [Required]
        [MaxLength(StreetMaxLength)]
        [Comment("Order billing address street name")]
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Order billing address post code
        /// </summary>
        [Required]
        [MaxLength(PostCodeMaxLength)]
        [Comment("Order billing address post code")]
        public string PostCode { get; set; } = string.Empty;

        /// <summary>
        /// Order billing address city
        /// </summary>
        [Required]
        [MaxLength(CityMaxLength)]
        [Comment("Order billing address city")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Order billing address country identificator
        /// </summary>
        [Required]
        [Comment("Order billing address country identificator")]
        public int CountryId { get; set; }

        /// <summary>
        /// Order billing address country
        /// </summary>
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; } = null!;
    }
}