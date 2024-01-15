using System;

namespace _05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double precentageAmountSpent = 0;
            string destination = string.Empty;
            string rest = string.Empty;

            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            if (budget >= 0 && budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    rest = "Camp";
                    precentageAmountSpent = 0.30;
                }
                else if (season == "winter")
                {
                    rest = "Hotel";
                    precentageAmountSpent = 0.70;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    rest = "Camp";
                    precentageAmountSpent = 0.40;
                }
                else if (season == "winter")
                {
                    rest = "Hotel";
                    precentageAmountSpent = 0.80;
                }
            }
            else if (budget > 1000)
            {
                rest = "Hotel";
                destination = "Europe";
                precentageAmountSpent = 0.90;
            }

            double price = budget * precentageAmountSpent;

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{rest} - {price:f2}");
        }
    }
}
