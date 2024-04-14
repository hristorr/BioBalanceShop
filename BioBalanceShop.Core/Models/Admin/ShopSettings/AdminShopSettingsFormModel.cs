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
using static BioBalanceShop.Infrastructure.Constants.DataConstants.OrderData;
using static BioBalanceShop.Core.Constants.MessageConstants;


namespace BioBalanceShop.Core.Models.Admin.ShopSettings
{
    public class AdminShopSettingsFormModel
    {
        /// <summary>
        /// Shop currency
        /// </summary>
        [Required]
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }

        public IEnumerable<ShopCurrencyServiceModel> Currencies { get; set; } = new List<ShopCurrencyServiceModel>();

        /// <summary>
        /// Shipping fee rate applied to order amount
        /// </summary>
        [Display(Name = "Shipping fee:")]
        [Range(typeof(decimal),
            ShipppingFeeMinValue,
            ShipppingFeeMaxValue,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = RangeErrorMessage)]
        public decimal? ShippingFeeRate { get; set; }

    }
}
