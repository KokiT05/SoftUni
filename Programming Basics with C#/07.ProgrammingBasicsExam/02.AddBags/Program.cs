using System;

namespace _02.AddBags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double price = 0;
            double totalPrice = 0;

            double baggageCost = double.Parse(Console.ReadLine());
            double kilogramsOfBaggage = double.Parse((Console.ReadLine()));
            int days = int.Parse(Console.ReadLine());
            int numberOfBags = int.Parse(Console.ReadLine());

            if (kilogramsOfBaggage < 10)
            {
                price = baggageCost * 0.20;
            }
            else if (kilogramsOfBaggage >= 10 && kilogramsOfBaggage <= 20)
            {
                price = baggageCost * 0.50;
            }
            else if (kilogramsOfBaggage >= 20)
            {
                price = baggageCost;
            }

            if (days > 30)
            {
                price = price + (price * 0.10);
            }
            else if (days >= 7 && days <= 30)
            {
                price = price + (price * 0.15);
            }
            else if (days < 7 && days > 0)
            {
                price = price + (price * 0.40);
            }

            totalPrice = price * numberOfBags;

            Console.WriteLine($"The total price of bags is: {totalPrice:f2} lv.");
        }
    }
}
