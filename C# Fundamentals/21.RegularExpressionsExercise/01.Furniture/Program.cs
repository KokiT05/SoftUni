using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal totalPrice = 0;
            List<string> furnitures = new List<string>();
            string furniture = string.Empty;
            decimal price = 0;
            int quantity = 0;

            string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<price>\d+\,?\d+)!(?<quantity>\d)";
            Regex regex = new Regex(pattern);
            MatchCollection matchCollection;

            string inputLine = Console.ReadLine();

            while (inputLine.ToLower() != "purchase")
            {
                matchCollection = regex.Matches(inputLine);

                foreach (Match match in matchCollection)
                {
                    furniture = match.Groups["furniture"].Value;
                    price = decimal.Parse(match.Groups["price"].Value);
                    quantity = int.Parse(match.Groups["quantity"].Value);

                    totalPrice += (price * quantity);
                    furnitures.Add(furniture);
                }

                inputLine = Console.ReadLine();
            }

            foreach (string currentFurniture in furnitures)
            {
                Console.WriteLine(currentFurniture);
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}