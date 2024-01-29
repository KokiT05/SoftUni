namespace _01.TennisEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceOfOneTennisRacket = double.Parse(Console.ReadLine());
            int NumberOfTennisRackets = int.Parse(Console.ReadLine());
            int numberOfPairsOfSneakers = int.Parse(Console.ReadLine());
            

            double finalPriceForRockets = priceOfOneTennisRacket * NumberOfTennisRackets;
            double finalPriceForSneakers = (priceOfOneTennisRacket * 1 / 6.00) * numberOfPairsOfSneakers;

            double totalPrice = (finalPriceForRockets + finalPriceForSneakers) * 0.20 ;

            double result = finalPriceForRockets + finalPriceForSneakers + totalPrice;

            double priceForDjokovic = result / 8;
            double priceForSponsors = result * (7 / 8.00);

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(priceForDjokovic)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(priceForSponsors)}");
        }
    }
}