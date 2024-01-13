using System;

namespace _12.TradeCommissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double commission = 0;
            town = town.ToLower();
            double result = 0;

            if (town == "sofia")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commission = 0.05;
                    result = commission * sales;
                    Console.WriteLine($"{result:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commission = 0.07;
                    result = commission * sales;
                    Console.WriteLine($"{result:f2}");
                }
                else if (sales > 1000 && sales <= 10_000)
                {
                    commission = 0.08;
                    result = commission * sales;
                    Console.WriteLine($"{result:f2}");
                }
                else if (sales > 10_000)
                {
                    commission = 0.12;
                    result = commission * sales;
                    Console.WriteLine($"{result:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (town == "plovdiv")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commission = 0.055;
                    result = commission * sales;
                    Console.WriteLine($"{result:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commission = 0.08;
                    result = commission * sales;
                    Console.WriteLine($"{result:f2}");
                }
                else if (sales > 1000 && sales <= 10_000)
                {
                    commission = 0.12;
                    result = commission * sales;
                    Console.WriteLine($"{result:f2}");
                }
                else if (sales > 10_000)
                {
                    commission = 0.145;
                    result = commission * sales;
                    Console.WriteLine($"{result:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (town == "varna")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commission = 0.045;
                    result = commission * sales;
                    Console.WriteLine($"{result:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commission = 0.075;
                    result = commission * sales;
                    Console.WriteLine($"{result:f2}");
                }
                else if (sales > 1000 && sales <= 10_000)
                {
                    commission = 0.10;
                    result = commission * sales;
                    Console.WriteLine($"{result:f2}");
                }
                else if (sales > 10_000)
                {
                    commission = 0.13;
                    result = commission * sales;
                    Console.WriteLine($"{result:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
