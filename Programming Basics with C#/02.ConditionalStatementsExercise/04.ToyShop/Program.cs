using System;

namespace _0._4ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double puzzel = 2.60;
            double talkingDoll = 3;
            double teddyBear = 4.10;
            double minion = 8.20;
            double truck = 2;

            double pricePerExcursion = double.Parse(Console.ReadLine());
            int numberPuzzeles = int.Parse(Console.ReadLine());
            int numberTalkingDolls = int.Parse(Console.ReadLine());
            int numberTeddyBears = int.Parse(Console.ReadLine());
            int numberMinions = int.Parse(Console.ReadLine());
            int numberTrucks = int.Parse(Console.ReadLine());

            int totalNumberToys = numberPuzzeles + numberTalkingDolls +
                                    numberTeddyBears + numberMinions + numberTrucks;

            double totalCostPuzzles = numberPuzzeles * puzzel;
            double totalCostTalkingDoll = numberTalkingDolls * talkingDoll;
            double totalCostTeddyBears = numberTeddyBears * teddyBear;
            double totalCostMinions = numberMinions * minion;
            double totalCostTrucks = numberTrucks * truck;

            double totalCostToys = totalCostTalkingDoll + totalCostTrucks
                                            + totalCostMinions + totalCostTeddyBears
                                            + totalCostPuzzles;

            if (totalNumberToys >= 50)
            {
                totalCostToys = totalCostToys - (totalCostToys * 0.25);
            }

            totalCostToys = totalCostToys - (totalCostToys * 0.10);

            double result = Math.Abs(totalCostToys - pricePerExcursion);
            if (totalCostToys >= pricePerExcursion)
            {
                Console.WriteLine($"Yes! {result:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {result:f2} lv needed.");
            }
        }
    }
}
