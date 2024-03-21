using System;
using System.Linq;

namespace _06.EqualSums
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

            bool isFound = false;
            int sumRight = 0;
            int sumLeft = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sumRight = 0;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    sumRight += numbers[j];
                }

                sumLeft = 0;

                for (int j = i - 1; j >= 0; j--)
                {
                    sumLeft += numbers[j];
                }

                if (sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}
