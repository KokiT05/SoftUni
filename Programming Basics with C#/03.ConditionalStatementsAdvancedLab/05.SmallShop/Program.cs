using System;

namespace _05.SmallShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double coffee = 0;
            double water = 0;
            double beer = 0;
            double sweets = 0;
            double peanuts = 0;
            double price = 0;

            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            if (town.ToLower() == "sofia")
            {
                if (product.ToLower() == "coffee")
                {
                    coffee = 0.50;
                    price = coffee * amount;
                }
                else if (product.ToLower() == "water")
                {
                    water = 0.80;
                    price = water * amount;
                }
                else if(product.ToLower() == "beer")
                {
                    beer = 1.20;
                    price = beer * amount;
                }
                else if (product.ToLower() == "sweets")
                {
                    sweets = 1.45;
                    price = sweets * amount;
                }
                else if (product.ToLower() == "peanuts")
                {
                    peanuts = 1.60;
                    price = peanuts * amount;
                }
            }
            else if (town.ToLower() == "plovdiv")
            {
                if (product.ToLower() == "coffee")
                {
                    coffee = 0.40;
                    price = coffee * amount;
                }
                else if (product.ToLower() == "water")
                {
                    water = 0.70;
                    price = water * amount;
                }
                else if (product.ToLower() == "beer")
                {
                    beer = 1.15;
                    price = beer * amount;
                }
                else if (product.ToLower() == "sweets")
                {
                    sweets = 1.30;
                    price = sweets * amount;
                }
                else if (product.ToLower() == "peanuts")
                {
                    peanuts = 1.50;
                    price = peanuts * amount;
                }
            }
            else if (town.ToLower() == "varna")
            {
                if (product.ToLower() == "coffee")
                {
                    coffee = 0.45;
                    price = coffee * amount;
                }
                else if (product.ToLower() == "water")
                {
                    water = 0.70;
                    price = water * amount;
                }
                else if (product.ToLower() == "beer")
                {
                    beer = 1.10;
                    price = beer * amount;
                }
                else if (product.ToLower() == "sweets")
                {
                    sweets = 1.35;
                    price = sweets * amount;
                }
                else if (product.ToLower() == "peanuts")
                {
                    peanuts = 1.55;
                    price = peanuts * amount;
                }
            }

            Console.WriteLine(price);
        }
    }
}
