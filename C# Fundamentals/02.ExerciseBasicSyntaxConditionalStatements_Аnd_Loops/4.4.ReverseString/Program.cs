using System;

namespace _4._4.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string newText = string.Empty;

            string text = Console.ReadLine();

            for (int i = text.Length - 1; i >= 0; i--)
            {
                newText += text[i];
            }

            Console.WriteLine(newText);
        }
    }
}
