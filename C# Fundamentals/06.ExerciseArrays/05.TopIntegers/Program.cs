using System;
using System.Linq;

namespace _05.TopIntegers
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

            int currentNumber = 0;
            bool isBiggest = true;

            for (int i = 0; i < numbers.Length; i++)
            {
                currentNumber = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (currentNumber <= numbers[j])
                    {
                        isBiggest = false;
                        break;
                    }
                }

                if (isBiggest)
                {
                    Console.Write($"{currentNumber} ");
                }

                isBiggest = true;
            }

        }
    }
}