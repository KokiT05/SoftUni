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

            int[] newArray = new int[numbers.Length];
            int biggestNumber = numbers[0];
            int point = 0;
            int biggestNumberIndex = 0;

            bool isBiggest = true;
            for (int i = 0; i < numbers.Length - 1; i++)
            {

                if (numbers[i] > numbers[i + 1] || i == numbers.Length - 2)
                {
                    if (i == numbers.Length - 2)
                    {
                        newArray[i] = numbers[i + 1];
                    }
                    else
                    {
                        newArray[i] = numbers[i];
                    }
                }
                else
                {
                    newArray[i] = 0;
                }
            }

            Console.WriteLine(string.Join(' ', newArray));
        }
    }
}
