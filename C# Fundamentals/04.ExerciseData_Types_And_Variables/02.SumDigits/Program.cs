using System;

namespace _02.SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int digit = 0;
            int sumDigits = 0;

            int number = int.Parse(Console.ReadLine());

            while (number > 0)
            {
                digit = number % 10;
                sumDigits += digit;
                number = number / 10;
            }

            Console.WriteLine(sumDigits);
        }
    }
}
