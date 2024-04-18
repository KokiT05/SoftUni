using System.Collections.Generic;

namespace _1.SumAdjacentEqualNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numberList = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(double.Parse)
                                    .ToList();

            SumEqualNumber(numberList);

            Console.WriteLine(string.Join(' ', numberList));
        }

        static void SumEqualNumber(List<double> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    numbers[i + 1] = numbers[i] + numbers[i + 1];
                    numbers.RemoveAt(i);
                    i = -1;
                }
            }
        }
    }
}