using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isSpecial;
            int sum;
            int number;

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                isSpecial = false;
                sum = 0;
                number = i;

                while (number != 0)
                {
                    sum += number % 10;
                    number = number / 10;
                }

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    isSpecial = true;
                }

                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
