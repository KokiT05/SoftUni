using System;

namespace _09.Chars_To_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstSumbol = char.Parse(Console.ReadLine());
            char secondSumbol = char.Parse(Console.ReadLine());
            char thirdSumbol = char.Parse(Console.ReadLine());

            string text = firstSumbol.ToString() + secondSumbol.ToString() + thirdSumbol.ToString();
            Console.WriteLine(text);
        }
    }
}
