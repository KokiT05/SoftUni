using System;
using System.Security.Cryptography.X509Certificates;

namespace _03.NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rose = 5;
            double dahlia = 3.80;
            double tulip = 2.80;
            double narcissus = 3;
            double gladiolus = 2.50;

            double price = 0;
            double discount = 0;
            double moreExpensive = 0;
            double result = 0;

            string kindOfFlowers = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            if (kindOfFlowers == "Roses")
            {
                price = rose;
                if (numberOfFlowers > 80)
                {
                    discount = 0.10;
                }

            }
            else if (kindOfFlowers == "Dahlias")
            {
                price = dahlia;
                if (numberOfFlowers > 90)
                {
                    discount = 0.15;
                }
            }
            else if (kindOfFlowers == "Tulips")
            {
                price = tulip;
                if (numberOfFlowers > 80)
                {
                    discount = 0.15;
                }
            }
            else if (kindOfFlowers == "Narcissus")
            {
                price = narcissus;
                if (numberOfFlowers < 120)
                {
                    moreExpensive = 0.15;
                }
            }
            else if (kindOfFlowers == "Gladiolus")
            {
                price = gladiolus;
                if (numberOfFlowers < 80)
                {
                    moreExpensive = 0.20;
                }
            }

            result = price * numberOfFlowers;

            if (discount != 0)
            {
                result = result - (result * discount);
            }
            else if (moreExpensive != 0)
            {
                result = result + (result * moreExpensive);
            }

            if (budget >= result)
            {
                Console.WriteLine($"Hey, you have a great garden with " +
                    $"{numberOfFlowers} {kindOfFlowers} and {(budget - result):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(result - budget):f2} " +
                    $"leva more.");
            }
        }
    }
}
