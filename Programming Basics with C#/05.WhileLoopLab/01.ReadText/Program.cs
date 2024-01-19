using System;

namespace _01.ReadText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            text = text.ToLower();
            while (text != "stop")
            {
                Console.WriteLine(text);
                text = Console.ReadLine();
                text = text.ToLower();
            }
        }
    }
}
