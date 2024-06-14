using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string listOfNames = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(listOfNames);

            foreach (Match match in matches) 
            {
                Console.Write($"{match.Value} ");
            }

            Console.WriteLine();
        }
    }
}