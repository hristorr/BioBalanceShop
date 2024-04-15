using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Exceptions
{
    public class PaymentErrorException : Exception
    {
        public PaymentErrorException() { }

        public PaymentErrorException(string message) : base(message) { }
    }
}
