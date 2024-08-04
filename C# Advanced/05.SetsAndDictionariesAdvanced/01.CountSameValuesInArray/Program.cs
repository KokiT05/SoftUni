using System.Globalization;

namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            double[] numbers = Console
                                .ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(double.Parse)
                                .ToArray();

            Dictionary<double, int> countOfNumbers = new Dictionary<double, int>();

            foreach (double number in numbers)
            {
                if (!countOfNumbers.ContainsKey(number))
                {
                    countOfNumbers.Add(number, 0);
                }

                countOfNumbers[number]++;
            }

            foreach (KeyValuePair<double, int> number in countOfNumbers)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
