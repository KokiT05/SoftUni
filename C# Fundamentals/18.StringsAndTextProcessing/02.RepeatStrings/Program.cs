using System.Text;

namespace _02.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            string[] inputWords = Console.ReadLine().Split(' ');

            foreach (string word in inputWords)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    result.Append(word);
                }
            }

            Console.WriteLine(result);
        }
    }
}