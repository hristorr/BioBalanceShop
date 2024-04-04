using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const string DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";

        public static class Product
        {
            public const int ProductCodeMaxLength = 20;
            public const int ProductCodeMinLength = 3;

            public const int TitleMaxLength = 250;
            public const int TitleMinLength = 2;

            public const int SubtitleMaxLength = 500;
            public const int SubtitleMinLength = 2;

            public const int DescriptionMaxLength = 3000;
            public const int DescriptionMinLength = 10;

            public const int IngredeientsMaxLength = 3000;
            public const int IngredeientsMinLength = 10;

            public const int ImageUrlMaxLength = 500;
            public const int ImageUrlMinLength = 5;

            public const int QuantityMaxRange = int.MaxValue;
            public const int QuantityMinRange = 0;
        }

        public static class Category
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;
        }

        public static class Country
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;

            public const int CountryCodeMaxLength = 3;
            public const int CountryCodeMinLength = 3;
            public const string CountryCodeRegexPattern = "[A-Z]{3}";
        }

        public static class Order
        {
            public const int OrderNumberMaxLength = 20;
            public const int OrderNumberMinLength = 5;
        }

        public static class Address
        {
            public const int StreetMaxLength = 50;
            public const int StreetMinLength = 5;

            public const int PostCodeMaxLength = 10;
            public const int PostCodeMinLength = 2;

            public const int CityMaxLength = 20;
            public const int CityMinLength = 1;
        }

        public static class User
        {
            public const int NameMaxLength = 25;
            public const int NameMinLength = 2;
        }

        public static class Currency
        {
            public const int CurrencyCodeMaxLength = 3;
            public const int CurrencyCodeMinLength = 3;
            public const string CurrencyCodeRegexPattern = "[A-Z]{3}";

            public const int CurrencySymbolMaxLength = 3;
            public const int CurrencySymbolMinLength = 1;
        }
    }
}
