using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Exceptions
{
    public class ProductOutOfStockException : Exception
    {
        public ProductOutOfStockException() { }

        public ProductOutOfStockException(string message) : base(message) { }
    }
}
