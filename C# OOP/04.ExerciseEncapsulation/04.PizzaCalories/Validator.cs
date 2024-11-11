using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public static class Validator
    {
        public static void TrowIfNumberIsNotInRange(double value, int min, int max, string exceptionMessage)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        public static void ThrowIfValueIsNotAllowed
            (HashSet<string> allowedValues, 
            string value, 
            string exceptionMessage)
        {
            if (!allowedValues.Contains(value))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
