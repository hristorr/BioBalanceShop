﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models
{
    public class ProductQueryServiceModel
    {
        public int TotalProductsCount { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; set; } = new List<ProductServiceModel>();
    }
}
