using System;

namespace _04.SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCombinations = 0;
            bool isFound = false;

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    numberOfCombinations++;

                    if (i + j == magicNumber)
                    {
                        start = i;
                        end = j;
                        isFound = true;
                        break;
                    }
                }

                if (isFound == true)
                {
                    break;
                }
            }

            if (isFound)
            {
                Console.WriteLine($"Combination N:{numberOfCombinations} ({start} + {end} = {magicNumber})");
            }
            else
            {
                Console.WriteLine($"{numberOfCombinations} combinations - neither equals {magicNumber}");
            }
        }
    }
}
