using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> customers
                = new Dictionary<string, Dictionary<string, double>>(); 

            string patternName = @"%(?<customer>[A-Z][a-z]+)%";
            string patternProduct = @"<(?<product>[A-Za-z]+)>";
            string patternCount = @"\|(?<count>\d+)\|";
            string patternPrice = @"(?<price>\d+\.?\d+)";
            string patterm =
            @"%(?<customer>[A-Z][a-z]+)%<(?<product>[A-Za-z]+)>\|(?<count>\d+)\|(?<price>\d+\.?\d+)";

            Regex regex = new Regex(patterm);
            MatchCollection matchCollection;

            string customerName = string.Empty;
            string product = string.Empty;
            int count = 0;
            double price = 0;

            string input = Console.ReadLine();
            while (input.ToLower() != "end of shift")
            {
                matchCollection = regex.Matches(input);

                foreach (Match match in matchCollection)
                {
                    customerName = match.Groups["customer"].Value;
                    product = match.Groups["product"].Value;
                    count = int.Parse(match.Groups["count"].Value);
                    price = double.Parse(match.Groups["price"].Value);

                    if (customers.ContainsKey(customerName) == false)
                    {
                        customers.Add(customerName, new Dictionary<string, double>
                        { {product, (count * price) } });
                    }
                    else if (customers[customerName].ContainsKey(product) == false)
                    {
                        customers[customerName].Add(product, price);
                    }
                }

                input = Console.ReadLine();
            }

            double totalMoney = 0;
            foreach (string customer in customers.Keys)
            {
                foreach (KeyValuePair<string, double> currentCustomerData in customers[customer])
                {
                    Console.WriteLine
                    ($"{customer}: {currentCustomerData.Key} - {currentCustomerData.Value:f2}");
                    totalMoney += currentCustomerData.Value;
                }
            }

            Console.WriteLine($"Total income: {totalMoney:f2}");

        }
    }
}