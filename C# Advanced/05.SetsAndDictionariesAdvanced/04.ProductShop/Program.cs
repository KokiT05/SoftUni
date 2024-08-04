using System.Globalization;

namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            SortedDictionary<string, Dictionary<string, double>> shopsProducts =
                new SortedDictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();
            while (input != "Revision")
            {
                string[] splitInput = input.Split(", ");
                string shop = splitInput[0];
                string product = splitInput[1];
                double price = double.Parse(splitInput[2]);

                if (!shopsProducts.ContainsKey(shop))
                {
                    shopsProducts.Add(shop, new Dictionary<string, double>());
                }

                if (!shopsProducts[shop].ContainsKey(product))
                {
                    shopsProducts[shop].Add(product, price);
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Dictionary<string, double>> shop in shopsProducts)
            {
                Console.WriteLine($"{shop.Key} ->");

                foreach (KeyValuePair<string, double> product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
