using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Constants
{
    public static class MessageConstants
    {
        public const string RequiredMessage = "The {0} value is required";

        public const string LengthMessage = "The value {0} must be between {2} and {1} characters long";

        public const string AmountRangeMessage = "{0} must be a positive number and less than {2}";

        public const string UserMessageSuccess = "UserMessageSuccess";

        public const string UserMessageError = "UserMessageError";
    }
}
