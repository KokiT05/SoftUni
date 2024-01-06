using System;

namespace _08.PetShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            double dogFoodPackaging = 2.50;
            double catFoodPackaging = 4;

            int numberOfDogFoodPackaging = int.Parse(Console.ReadLine());
            int numberOfCatFoodPackaging = int.Parse(Console.ReadLine());

            double dogFoodPackagingPrice = numberOfDogFoodPackaging * dogFoodPackaging;
            double catFoodPackagingPrice = numberOfCatFoodPackaging * catFoodPackaging;

            Console.WriteLine($"{catFoodPackagingPrice + dogFoodPackagingPrice} lv.");
        }
    }
}
