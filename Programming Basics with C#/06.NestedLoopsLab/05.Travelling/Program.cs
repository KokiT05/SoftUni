using System;

namespace _05.Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double savedMoney = 0;
            double sum = 0;

            string destination = Console.ReadLine();
            double price = double.Parse(Console.ReadLine());

            while (destination != "End")
            {
                for (int i = 0; i < price; i++)
                {
                    savedMoney = double.Parse(Console.ReadLine());
                    sum += savedMoney;

                    if (sum >= price)
                    {
                        Console.WriteLine($"Going to {destination}");
                        break;
                    }
                }

                destination = Console.ReadLine();
                price = double.Parse(Console.ReadLine());
            }
        }
    }
}
