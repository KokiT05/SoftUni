using System;

namespace _02.Pounds_To_Dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal britishPounds = decimal.Parse(Console.ReadLine());

            decimal USEDollars = britishPounds * 1.31M;

            Console.WriteLine($"{USEDollars:f3}");
        }
    }
}
