using System;
using System.Linq;
using System.Reflection;

namespace _04.ArrayRotation
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


            int rotations = int.Parse(Console.ReadLine());
            int currentNumber = 0;

            for (int i = 0; i < rotations; i++)
            {

                for (int j = 0; j < numbers.Length; j++)
                {
                    currentNumber = numbers[j];

                    if (j < numbers.Length - 1)
                    {
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = currentNumber;
                    }
                    else
                    {
                        numbers[j] = currentNumber;
                    }
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
