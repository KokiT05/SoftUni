using System;
using System.Collections.Generic;

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
                    if (int.Parse(inputData[1]) < 0 || int.Parse(inputData[2]) >= numbers.Count)
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
                    int count = int.Parse(inputData[2]);
                    for (int i = 1; i < count; i++)
                    {
                        int lastValue = numbers.Last();
                        for (int j = numbers.Count - 1; j > 0; j--)
                        {
                            numbers[j] = numbers[j - 1];
                        }
                        numbers[0] = lastValue;
                    }
                }
                else if (command == "shift" && inputData[1].ToLower() == "right" && numbers.Count != 0)
                {
                    int count = int.Parse(inputData[2]);
                    for (int i = 1; i < count; i++)
                    {
                        int firstValue = numbers[0];
                        for (int j = 0; j < numbers.Count - 1; j++)
                        {
                            numbers[j] = numbers[j + 1];
                        }
                        numbers[numbers.Count-1] = firstValue;
                    }
                }

                inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}