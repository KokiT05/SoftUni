using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string value, string exceptionMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        public static void ThrowIfNumberIsNegative(decimal number, string exceptionMessage)
        {
            if (number < 0)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
