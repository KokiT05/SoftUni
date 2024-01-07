using System;

namespace _01.USDtoBGN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            decimal usd = decimal.Parse(Console.ReadLine());
            // 1 usd = 1.79549
            decimal course = 1.79549M;
            decimal bgn = usd * course;
            Console.WriteLine(bgn);
        }
    }
}
