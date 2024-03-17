using System;
using System.Globalization;
using System.Linq;

namespace _02.PrintNumbers_In_ReverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int number = 0;

            int[] numbers = new int[lines];
            for (int i = 0; i < lines; i++)
            {
                number = int.Parse(Console.ReadLine());
                numbers[i] = number;
            }

            // Method 1
            Console.WriteLine(string.Join(' ', numbers.Reverse()));

            // Method 2
            /*numbers = numbers.Reverse().ToArray();

            foreach (int numberItem in numbers)
            {
                Console.Write($"{numberItem} ");
            }*/

            // Method 3
            /*for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write($"{numbers[i]} ");
            }*/
        }
    }
}
