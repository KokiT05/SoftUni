using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _07.Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double discount = 0;

            double budget = double.Parse(Console.ReadLine());

            double videoCardPrice = 250;
            int numberVideoCards = int.Parse(Console.ReadLine());
            double totalPriceVideoCards = (videoCardPrice * numberVideoCards);

            double processorsPrice = (totalPriceVideoCards * 0.35);
            int numberProcessors = int.Parse(Console.ReadLine());
            double totalProcessorsPrice = numberProcessors * processorsPrice;

            double ramMemory = (totalPriceVideoCards * 0.10);
            int numberRamMemory = int.Parse(Console.ReadLine());
            double totalRamMemoryPrice = numberRamMemory * ramMemory;

            double totalPrice = totalProcessorsPrice + totalPriceVideoCards + totalRamMemoryPrice;
            if (numberVideoCards > numberProcessors)
            {
                discount = 0.15;
                totalPrice = totalPrice - (totalPrice * discount);
            }

            double result = Math.Abs(budget - totalPrice);
            if (budget >= totalPrice)
            {
                Console.WriteLine($"You have {result:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {result:f2} leva more!");
            }
        }
    }
}
