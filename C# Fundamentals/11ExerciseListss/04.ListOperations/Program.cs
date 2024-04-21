using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _04.ListOperations
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
                string command = inputData[0].ToLower();

                if (command == "add")
                {
                    numbers.Add(int.Parse(inputData[1]));
                }
                else if (command == "insert")
                {
                    if (int.Parse(inputData[2]) < 0 || int.Parse(inputData[2]) >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(int.Parse(inputData[2]), int.Parse(inputData[1]));
                    }
                }
                else if (command == "remove")
                {
                    if (int.Parse(inputData[1]) < 0 || int.Parse(inputData[1]) >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(int.Parse(inputData[1]));
                    }
                }
                else if (command == "shift" && inputData[1].ToLower() == "left" && numbers.Count != 0)
                {
                    int task = int.Parse(inputData[2]);
                    while (task != 0)
                    {
                        int currentnumber = numbers[0];
                        numbers.RemoveAt(0);
                        numbers.Add(currentnumber);
                        task--;
                    }
                }
                else if (command == "shift" && inputData[1].ToLower() == "right" && numbers.Count != 0)
                {
                    int count = int.Parse(inputData[2]);
                    while (count != 0)
                    {
                        int currentnumber = numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                        numbers.Insert(0, currentnumber);
                        count--;
                    }
                }

                inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}