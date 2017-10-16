using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Common
{
    public class ValidationConstants
    {
        public const int CategoryMinLength = 5;
        public const int CategoryMaxLength = 50;
        public const string MinLengthFieldErrorMessage = "Field {0} must be min {1} symbols";
        public const string MaxLengthFieldErrorMessage = "Field {0} must be max {1} symbols";

    }
}
