using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Order
{
    public class OrderRecipientDetailsModel
    {
        /// <summary>
        /// Order recipient identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order recipient first name
        /// </summary>
        [PersonalData]
        public string? FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Order recipient last name
        /// </summary>
        [PersonalData]
        public string? LastName { get; set; } = string.Empty;

        /// <summary>
        /// Order recipient phone number
        /// </summary>
        [PersonalData]
        public string? PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Order recipient email address
        /// </summary>
        [PersonalData]
        public string? EmailAddress { get; set; } = string.Empty;
    }
}