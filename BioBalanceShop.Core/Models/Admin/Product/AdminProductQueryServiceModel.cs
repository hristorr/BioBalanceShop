using BioBalanceShop.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Admin.Product
{
    public class AdminProductQueryServiceModel
    {
        public int TotalProductsCount { get; set; }

        public IEnumerable<AdminProductServiceModel> Products { get; set; } = new List<AdminProductServiceModel>();
    }
}
