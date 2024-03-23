using System;
using System.Linq;

namespace _05.TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console
                                .ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            bool isTopInteger = true;

            for (int i = 0; i < inputArray.Length; i++)
            {
                int currentNumber = inputArray[i];
                isTopInteger = true;

                for (int j = i + 1;  j < inputArray.Length;  j++)
                {
                    if (currentNumber <= inputArray[j])
                    {
                        isTopInteger = false;
                        break;
                    }
                }

                if (isTopInteger)
                {
                    Console.Write($"{inputArray[i]} ");
                }
            }

            //Console.WriteLine(string.Join(" ", inputArray));
        }
    }
}