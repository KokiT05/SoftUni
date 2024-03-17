using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
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

            int evenSum = 0;
            int oddSum = 0;

            int currentNumber = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
               currentNumber = numbers[i];

                if (currentNumber % 2 == 0)
                {
                    evenSum += currentNumber;
                }
                else
                {
                    oddSum += currentNumber;
                }
            }

            int result = evenSum - oddSum;
            Console.WriteLine(result);
        }
    }
}
