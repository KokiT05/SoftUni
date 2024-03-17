using System;
using System.Linq;

namespace _05.SumEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int[] numbers = input
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int sum = 0;
            for (int i = 1; i <= numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sum += numbers[i - 1];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
