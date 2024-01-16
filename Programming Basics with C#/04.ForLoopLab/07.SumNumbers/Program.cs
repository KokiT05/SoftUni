using System;

namespace _07.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int number = 0;

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
