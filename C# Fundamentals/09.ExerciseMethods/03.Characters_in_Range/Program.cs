using System.Text;

namespace _03.Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());
            string result = Characters(firstSymbol, secondSymbol);
            Console.WriteLine(result);

        }

        static string Characters(char start, char end)
        {
            char startValue = end;
            char endValue = start;

            if(start <= end) 
            {
                startValue = start;
                endValue = end;
            }

            StringBuilder output = new StringBuilder();

            for (int i = startValue + 1; i < endValue; i++)
            {
                output.Append((char)i);
                output.Append(" ");
            }

            return output.ToString();
        }
    }
}