using System;

namespace _04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double shipPriceSpring = 3000;
            double shipPriceSummerAutumn = 4200;
            double shipPriceWinter = 2600;
            double discount = 0;
            double price = 0;

            //int group = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberOfFishermen = int.Parse(Console.ReadLine());

            season = season.ToLower();

            if (season == "spring")
            {
                price = shipPriceSpring;
            }
            else if (season == "summer" || season == "autumn")
            {
                price = shipPriceSummerAutumn;
            }
            else if (season == "winter")
            {
                price = shipPriceWinter;
            }

            if (numberOfFishermen > 0 && numberOfFishermen <= 6)
            {
                discount = 0.10;
            }
            else if (numberOfFishermen >= 7 && numberOfFishermen <= 11)
            {
                discount = 0.15;
            }
            else if (numberOfFishermen >= 12)
            {
                discount = 0.25;
            }

            price = price - (price * discount);

            if (numberOfFishermen % 2 == 0 && season != "autumn")
            {
                discount =  0.05;
                price = price - (price * discount);
            }

            double result = Math.Abs(price - budget);

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {result:f2} leva left.");
            }
            else 
            {
                Console.WriteLine($"Not enough money! You need {result:f2} leva.");
            }
        }
    }
}
