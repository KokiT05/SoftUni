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
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            bool isFound = false;
            for (int currentIndex = 0; currentIndex < numbers.Length; currentIndex++)
            {
                int sumRigth = 0;

                for (int r = currentIndex + 1; r < numbers.Length; r++)
                {
                    sumRigth += numbers[r];
                }

                int sumLeft = 0;

                for (int l = currentIndex - 1; l >= 0; l--)
                {
                    sumLeft += numbers[l];
                }

                if (sumLeft == sumRigth)
                {
                    Console.Write(currentIndex);
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
