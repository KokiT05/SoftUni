using System;
using System.Linq;

namespace _08.MagicSum
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

            int number = int.Parse(Console.ReadLine());
            int currentNumber = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                currentNumber = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (currentNumber + numbers[j] == number)
                    {
                        Console.WriteLine($"{currentNumber} {numbers[j]}");
                    }
                }
            }
        }
    }
}
