using System;
using System.Collections.Generic;

namespace _3.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfCommand = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();

            //string[] inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < countOfCommand; i++)
            {
                string[] inputData = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = inputData[0];
                string states = inputData[2];


                if (states.ToLower() == "not")
                {
                    if (names.Contains(name) == true)
                    {
                        names.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else if (states.ToLower() == "going!")
                {
                    if (names.Contains(name) == true)
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        names.Add(name);
                    }
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, names));
            }
        }
    }
}