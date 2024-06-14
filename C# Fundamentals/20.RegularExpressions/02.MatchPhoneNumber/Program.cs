using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\+359)(\s|\-)2(\s|\-)[0-9]{3}(\s|\-)[0-9]{4}";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matchCollection = regex.Matches(input);
            
            string[] allPhoneNumber = matchCollection.Cast<Match>().Select(m => m.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", allPhoneNumber));
        }
    }
}