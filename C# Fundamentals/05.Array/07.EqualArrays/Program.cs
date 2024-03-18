using System;
using System.Linq;

namespace _07.EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mathod 1
            int[] firstArray = Console
                                .ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            int[] secondArray = Console
                                .ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            
            if (firstArray.Length == secondArray.Length)
            {
                bool isEqual = true;
                int currentIndex = 0;
                int firstArraySum = 0;
                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] != secondArray[i])
                    {
                        isEqual = false;
                        currentIndex = i;
                        break;
                    }
                    else
                    {
                        firstArraySum += firstArray[i];
                    }
                }

                if (isEqual)
                {
                    Console.WriteLine($"Arrays are identical. Sum: {firstArraySum}");
                }
                else
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {currentIndex} index");
                }
            }
        }
    }
}
