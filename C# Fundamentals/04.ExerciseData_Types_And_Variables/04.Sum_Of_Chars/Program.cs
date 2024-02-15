using System;

namespace _04.Sum_Of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char sumbol = ' ';
            int sumOfChar = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                sumbol = char.Parse(Console.ReadLine());
                sumOfChar += sumbol;
            }

            Console.WriteLine($"The sum equals: {sumOfChar}");
        }
    }
}
