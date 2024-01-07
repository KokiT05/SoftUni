using System;

namespace _07.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {

            decimal chickenMenu = 10.35M;
            decimal fishMenu = 12.40M;
            decimal vegetarianMenu = 8.15M;

            decimal delivery = 2.50M;

            int numberChickenMenus = int.Parse(Console.ReadLine());
            int numberFishMenus = int.Parse(Console.ReadLine());
            int numberVegetarianMenus = int.Parse(Console.ReadLine());

            decimal priceChickenMenus = numberChickenMenus * chickenMenu;
            decimal priceFishMenus = numberFishMenus * fishMenu;
            decimal priceVegetarianMenus = numberVegetarianMenus * vegetarianMenu;

            decimal totalSum = priceFishMenus + priceChickenMenus + priceVegetarianMenus;
            decimal priceDessert = (totalSum * 0.20M);
            totalSum = totalSum + priceDessert + delivery;

            Console.WriteLine(Math.Round(totalSum, 2));


        }
    }
}
