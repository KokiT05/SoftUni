using System.Text;
using System.Text.RegularExpressions;

namespace _05.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            string barcodePattern = @"(\@\#+)([A-Z][A-Za-z0-9]{5,})(\@\#+)";
            string productGroupPattern = @"\d+";

            Regex regex = new Regex(barcodePattern);

            for (int i = 1; i <= count; i++)
            {
                string barcode = Console.ReadLine();

                if (regex.IsMatch(barcode))
                {
                    Match match = regex.Match(barcode);


                    regex = new Regex(productGroupPattern);
                    if (regex.IsMatch(match.Value))
                    {
                        MatchCollection matchesProductGroup = regex.Matches(match.Value);
                        Console.Write($"Product group:");
                        Console.WriteLine($" {string.Join("", matchesProductGroup)}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid barcode");
                }

                regex = new Regex(barcodePattern);
            }
        }
    }
}