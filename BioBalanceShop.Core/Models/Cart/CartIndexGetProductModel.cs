﻿using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Cart
{
    public class CartIndexGetProductModel
    {
        public int ProductId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageURL { get; set; } = string.Empty;

        public int QuantityToOrder { get; set; }

        public int QuantityInStock { get; set; }

        public decimal Price { get; set; }

        public string CurrencySymbol { get; set; } = string.Empty;

        public bool CurrencyIsSymbolPrefix { get; set; }
    }
}