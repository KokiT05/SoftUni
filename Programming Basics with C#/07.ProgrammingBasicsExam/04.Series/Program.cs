using System;

namespace _04.Series
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isEnough = true;
            double totalPrice = 0;


            double thrones = 0.50;
            double lucifer = 0.40;
            double protector = 0.30;
            double totalDrama = 0.20;
            double area = 0.10;

            string name = string.Empty;
            double price = 0;

            double budget = double.Parse(Console.ReadLine());
            int numberOfSeries = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfSeries; i++)
            {
                name = Console.ReadLine();
                price = double.Parse(Console.ReadLine());

                if (name == "Thrones")
                {
                    price = price - (price * thrones);
                }
                else if (name == "Protector")
                {
                    price = price - (price * protector);
                }
                else if (name == "Lucifer")
                {
                    price = price - (price * lucifer);
                }
                else if (name == "TotalDrama")
                {
                    price = price - (price * totalDrama);
                }
                else if (name == "Area")
                {
                    price = price - (price * area);
                }

                totalPrice = totalPrice + price;

                if (totalPrice > budget)
                {
                    isEnough = false;
                }
            }

            double result = Math.Abs(budget - totalPrice);
            if (isEnough)
            {
                Console.WriteLine($"You bought all the series and left with {result:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {result:f2} lv. more to buy the series!");
            }
        }
    }
}
