using System;
using System.Data.SqlTypes;

namespace _09.KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthOfSequences = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            string sequences = string.Empty;
            while (command != "Clone them!")
            {
                sequences = sequences + "-" + command;
                command = Console.ReadLine();
            }

            sequences = sequences.Replace('-', ' ');

            string[] sequencesArray = sequences.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(string.Join(Environment.NewLine, sequencesArray));
        }
    }
}
