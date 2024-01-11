using System;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

namespace _05.GodzillaVS_Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal discount = 0;
            decimal decor = 0M;

            decimal budgetFilm = decimal.Parse(Console.ReadLine());
            int numberExtras = int.Parse(Console.ReadLine());
            decimal clothingExpenses = decimal.Parse(Console.ReadLine());

            if (numberExtras > 150)
            {
                discount = 0.10M;
            }


            decor = budgetFilm * 0.10M;
            decimal totalCostClothes = numberExtras * clothingExpenses;
            totalCostClothes = totalCostClothes - (totalCostClothes * discount);
            decimal expenses = totalCostClothes + decor;

            decimal result = Math.Abs(budgetFilm - expenses);
            if (expenses > budgetFilm)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {result:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {result:f2} leva left.");
            }
        }
    }
}
