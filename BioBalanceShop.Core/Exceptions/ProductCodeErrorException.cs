using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Exceptions
{
    public class ProductCodeErrorException : Exception
    {
        public ProductCodeErrorException() { }

        public ProductCodeErrorException(string message) : base(message) { }
    }
}
