using System;

namespace _06.Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {

            decimal protectiveNylon = 1.50M;
            decimal paint = 14.50M;
            decimal paintThinner = 5M;

            int amountNylon = int.Parse(Console.ReadLine());
            int amountPaint = int.Parse(Console.ReadLine());
            int amountPaintThinner = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            decimal extraLitersPaint = amountPaint * 0.10M;
            decimal extraMetersNylon = amountNylon + 2;
            decimal bag = 0.40M;

            decimal sumNylon = extraMetersNylon * protectiveNylon;
            decimal sumPainth = (amountPaint + extraLitersPaint) * paint;
            decimal sumPaintThinner = amountPaintThinner * paintThinner;

            decimal totalPrice = sumPainth + sumPaintThinner + sumNylon + bag;
            decimal wagesWorkers = (totalPrice * 0.30M) * hours;

            Console.WriteLine(Math.Round(totalPrice + wagesWorkers, 2));

        }
    }
}
