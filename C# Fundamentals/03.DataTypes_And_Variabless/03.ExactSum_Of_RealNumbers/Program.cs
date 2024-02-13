using System;
using System.Diagnostics;
using System.Numerics;

namespace _03.ExactSum_Of_RealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            decimal sum = 0M;
            decimal number = 0M;

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                number = decimal.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
