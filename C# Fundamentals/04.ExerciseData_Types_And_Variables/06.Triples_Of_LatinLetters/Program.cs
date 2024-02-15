using System;

namespace _06.Triples_Of_LatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            char firstChar = 'A';
            char secondChar = 'a';
            char thirdChar = 'a';

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    for (int k = 0; k <= n; k++)
                    {
                        firstChar = (char)('a' + i);
                        secondChar = (char)('a' + j);
                        thirdChar = (char)('a' + k);

                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }
        }
    }
}
