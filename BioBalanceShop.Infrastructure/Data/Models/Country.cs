using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.Country;

namespace BioBalanceShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Country data entity
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Country identificator
        /// </summary>
        [Key]
        [Comment("Country identificator")]
        public int Id { get; set; }

        /// <summary>
        /// Indicator if country exists
        /// </summary>
        [Required]
        [Comment("Indicator if country exists")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Country name
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Country name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Country code
        /// </summary>
        [Required]
        [MaxLength(CountryCodeMaxLength)]
        [RegularExpression(CountryCodeRegexPattern)]
        [Comment("Country code")]
        public string Code { get; set; } = string.Empty;

        [Required]
        [Comment("Shop identificator")]
        public int ShopId { get; set; }

        /// <summary>
        /// Shop
        /// </summary>
        [ForeignKey(nameof(ShopId))]
        public Shop Shop { get; set; } = null!;

        /// <summary>
        /// Customer shipping addresses
        /// </summary>
        public IEnumerable<CustomerShippingAddress> CustomerShippingAddresses { get; set; } = new List<CustomerShippingAddress>();

        /// <summary>
        /// Customer billing addresses
        /// </summary>
        public IEnumerable<CustomerBillingAddress> CustomerBillingAddresseses { get; set; } = new List<CustomerBillingAddress>();

        /// <summary>
        /// Order shipping addresses
        /// </summary>
        public IEnumerable<OrderShippingAddress> OrderShippingAddresses { get; set; } = new List<OrderShippingAddress>();

        /// <summary>
        /// Order billing addresses
        /// </summary>
        public IEnumerable<OrderBillingAddress> OrderBillingAddresseses { get; set; } = new List<OrderBillingAddress>();
    }
}
