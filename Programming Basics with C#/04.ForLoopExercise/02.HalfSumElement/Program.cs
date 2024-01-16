using System;

namespace _02.HalfSumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int number = 0;
            int maxNumber = int.MinValue;

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                number = int.Parse(Console.ReadLine());

                sum += number;

                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            int sumWithoutMaxNumber = sum - maxNumber;
            if (maxNumber == sumWithoutMaxNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + maxNumber);
            }
            else
            {
                int diff = Math.Abs(maxNumber - sumWithoutMaxNumber);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
