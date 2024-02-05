using System;

namespace _2.Divison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isDivisible = true;
            int division = 0;

            int number = int.Parse(Console.ReadLine());

            if (number % 10 == 0)
            {
                division = 10;
            }
            else if (number % 7 == 0)
            {
                division = 7;
            }
            else if (number % 6 == 0)
            {
                division = 6;
            }
            else if (number % 3 == 0)
            {
                division = 3;
            }
            else if (number % 2 == 0)
            {
                division = 2;
            }
            else
            {
                isDivisible = false;
            }

            if (isDivisible)
            {
                Console.WriteLine($"The number is divisible by {division}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
