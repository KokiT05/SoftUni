using System;

namespace _05.SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountPackPens = 5.80;
            double amountPackMarkers = 7.20;
            double literPreparation = 1.20;

            int numberPacksPens = int.Parse(Console.ReadLine());
            int numberPacksMarkers = int.Parse(Console.ReadLine());
            int litersPreparation = int.Parse(Console.ReadLine());
            int percentageReduction = int.Parse(Console.ReadLine());

            double discount = percentageReduction / 100.0;
            double totalАмоунтPens = numberPacksPens * amountPackPens;
            double totalAmountMarkers = numberPacksMarkers * amountPackMarkers;
            double totalAmountPreparation = litersPreparation * literPreparation;

            double total = (totalАмоунтPens + totalAmountMarkers + totalAmountPreparation);
            double totalWithDiscount = total - (total * discount);

            Console.WriteLine(totalWithDiscount);

        }
    }
}
