using System;
using System.Text;

namespace _06.ReversedChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());

            StringBuilder textSB = new StringBuilder();
            textSB.Append(thirdChar);
            textSB.Append(" ");
            textSB.Append(secondChar);
            textSB.Append(" ");
            textSB.Append(firstChar);
            string text = thirdChar + " " + secondChar + " " + firstChar;
            Console.WriteLine(textSB);
        }
    }
}
