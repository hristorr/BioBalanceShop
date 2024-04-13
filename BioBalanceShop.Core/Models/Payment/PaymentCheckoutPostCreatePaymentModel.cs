using BioBalanceShop.Infrastructure.Data.Enumerations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.PaymentData;
using static BioBalanceShop.Core.Constants.MessageConstants;
using static BioBalanceShop.Infrastructure.Constants.DataConstants.CurrencyData;

namespace BioBalanceShop.Core.Models.Payment
{
    /// <summary>
    /// Create payment model
    /// </summary>
    public class PaymentCheckoutPostCreatePaymentModel
    {
        /// <summary>
        /// Payment date
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Payment amount
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(typeof(decimal),
            PaymentAmountMinValue,
            PaymentAmountMaxValue,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Payment amount")]
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Payment status
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [EnumDataType(typeof(PaymentStatus))]
        [Comment("Payment status")]
        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>
        /// Payment currency code
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [MaxLength(CurrencyCodeMaxLength)]
        [RegularExpression(CurrencyCodeRegexPattern)]
        [Comment("Payment currency code")]
        public string CurrencyCode { get; set; } = string.Empty;
    }
}
