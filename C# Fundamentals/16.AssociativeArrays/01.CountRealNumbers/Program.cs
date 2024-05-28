using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            SortedDictionary<double, int> countOfNumbers = new SortedDictionary<double, int>();

            foreach (double number in numbers) 
            {
                if (countOfNumbers.ContainsKey(number))
                {
                    countOfNumbers[number]++;
                }
                else
                {
                    countOfNumbers.Add(number, 1);
                }
            }

            foreach (KeyValuePair<double, int> number in countOfNumbers)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}