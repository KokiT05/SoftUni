using System;
using System.Linq;

namespace _05.SumEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console
                            .ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int sum = 0;
            int currentNumber = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                currentNumber = numbers[i];

                if (currentNumber % 2 == 0)
                {
                    sum += currentNumber;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
