using System;
using System.Linq;
using System.Threading;

namespace _07.MaxSequence_Of_EqualElements
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

            int longestSequence = 1;
            int index = 0;

            int counter = 1;
            int currentNumber = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                counter = 1;
                currentNumber = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (currentNumber == numbers[j])
                    {
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (longestSequence < counter)
                {
                    longestSequence = counter;
                    index = i;
                }
            }

            for (int i = 0; i < longestSequence; i++)
            {
                Console.Write($"{numbers[i + index]} ");
            }
        }
    }
}
