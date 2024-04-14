//using BioBalanceShop.Infrastructure.Data.Enumerations;
//using BioBalanceShop.Infrastructure.Data.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static BioBalanceShop.Infrastructure.Constants.DataConstants.Order;
//using static BioBalanceShop.Core.Constants.MessageConstants;
//using BioBalanceShop.Core.Models._Base;
//using BioBalanceShop.Core.Models.Payment;

//namespace BioBalanceShop.Core.Models.Order
//{
//    public class OrderCreatePostModel
//    {
        

//        /// <summary>
//        /// Order status
//        /// </summary>
//        [Required(ErrorMessage = RequiredMessage)]
//        [Display(Name = "Order status")]
//        [EnumDataType(typeof(OrderStatus))]
//        public OrderStatus Status { get; set; }

//        /// <summary>
//        /// Order amount excluding shipping fee
//        /// </summary>
//        [Required(ErrorMessage = RequiredMessage)]
//        [Display(Name = "Order amount excluding shipping fee")]
//        [Range(typeof(decimal),
//            AmountMinValue,
//            AmountMaxValue,
//            ConvertValueInInvariantCulture = true,
//            ErrorMessage = AmountRangeMessage)]
//        public decimal Amount { get; set; }

//        /// <summary>
//        /// Order shipping fee
//        /// </summary>
//        [Required(ErrorMessage = RequiredMessage)]
//        [Display(Name = "Shipping fee")]
//        [Range(typeof(decimal),
//            AmountMinValue,
//            AmountMaxValue,
//            ConvertValueInInvariantCulture = true,
//            ErrorMessage = AmountRangeMessage)]
//        public decimal ShippingFee { get; set; }

//        /// <summary>
//        /// Order total amount including shipping fee
//        /// </summary>
//        [Required(ErrorMessage = RequiredMessage)]
//        [Display(Name = "Order total amount")]
//        [Range(typeof(decimal),
//            AmountMinValue,
//            AmountMaxValue,
//            ConvertValueInInvariantCulture = true,
//            ErrorMessage = AmountRangeMessage)]
//        public decimal TotalAmount { get; set; }

//        /// <summary>
//        /// Order currency
//        /// </summary>
//        [Required(ErrorMessage = RequiredMessage)]
//        [Display(Name = "Currency")]
//        public ShopCurrencyServiceModel Currency { get; set; } = null!;

//        /// <summary>
//        /// Customer
//        /// </summary>
//        [Required(ErrorMessage = RequiredMessage)]
//        [Display(Name = "Customer")]
//        public int CustomerId { get; set; }

//        /// <summary>
//        /// Order address
//        /// </summary>
//        [Required(ErrorMessage = RequiredMessage)]
//        [Display(Name = "Order address")]
//        public OrderCreatePostOrderAddressModel OrderAddress { get; set; } = null!;

//        /// <summary>
//        /// Payment identificator
//        /// </summary>
//        [Required(ErrorMessage = RequiredMessage)]
//        [Display(Name = "Payment")]
//        public PaymentCheckoutPostCreatePaymentModel Payment { get; set; } = null!;

//        /// <summary>
//        /// Order recipient identificator
//        /// </summary>
//        [Required(ErrorMessage = RequiredMessage)]
//        [Display(Name = "Order recipient")]
//        public OrderCreatePostOrderRecipientModel OrderRecipient { get; set; }

//        /// <summary>
//        /// Order items
//        /// </summary>
//        public IList<OrderCreatePostOrderItemModel> OrderItems { get; set; } = new List<OrderCreatePostOrderItemModel>();

//        public IEnumerable<PaymentCheckoutGetCountryModel> Countries { get; set; } = new List<PaymentCheckoutGetCountryModel>();
//    }
//}
