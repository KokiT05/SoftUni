using System.Collections.Generic;

namespace _2.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

            string[] inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (inputData[0].ToLower() != "end")
            {
                string command = inputData[0];

                if (command.ToLower() == "delete")
                {
                    numbers.Remove(int.Parse(inputData[1]));
                }
                else if (command.ToLower() == "insert")
                {
                    numbers.Insert(int.Parse(inputData[2]), int.Parse(inputData[1]));
                }

                inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}