using System;

namespace _05.PrintPart_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            string sumbols = string.Empty;

            for (int i = start; i <= end; i++)
            {
                sumbols += (char)i + " ";
            }

            Console.WriteLine(sumbols);
        }
    }
}
