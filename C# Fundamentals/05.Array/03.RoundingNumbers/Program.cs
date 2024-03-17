using System;
using System.Linq;

namespace _03.RoundingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            // Method 1
            double[] numbers = input
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(double.Parse)
                               .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    Console.WriteLine($"{numbers[i]} => 0");
                }
                else
                {
                    Console.WriteLine($"{numbers[i]} => {(int)Math.Round(numbers[i], MidpointRounding.AwayFromZero)}");
                }
            }
        }
    }
}
