using System;
using System.Linq;

namespace _03.Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int[] firstArray = new int[lines];
            int[] secondArray = new int[lines];

            int[] inputIntegers = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                inputIntegers = Console
                                .ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
                if (i % 2 == 0)
                {
                    firstArray[i] = inputIntegers[0];
                    secondArray[i] = inputIntegers[1];
                }
                else
                {
                    firstArray[i] = inputIntegers[1];
                    secondArray[i] = inputIntegers[0];
                }

            }

            Console.WriteLine(string.Join(' ', firstArray));
            Console.WriteLine(string.Join(' ', secondArray));
        }
    }
}
