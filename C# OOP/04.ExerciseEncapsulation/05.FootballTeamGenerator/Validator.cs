using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrWhiteSpace(string value, string exceptionMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        public static void ThrowIfNumberIsNotInRange(int value, int min, int max, string exceptionMessage)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
