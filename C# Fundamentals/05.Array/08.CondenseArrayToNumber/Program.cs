using System;
using System.Linq;
using System.Threading;

namespace _08.CondenseArrayToNumber
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

            int sumAdjacent = 0;
            int index = 1;
            for (int i = 1; i < inputArray.Length; i++)
            {
                sumAdjacent = inputArray[i - 1] + inputArray[i];
                inputArray[i - 1] = sumAdjacent;

                if (i == inputArray.Length - 1 && index <= i)
                {
                    i = 0;
                    inputArray[inputArray.Length - index] = 0;
                    index++;
                    continue;
                }
            }

            Console.WriteLine(inputArray[0]);
        }
    }
}
