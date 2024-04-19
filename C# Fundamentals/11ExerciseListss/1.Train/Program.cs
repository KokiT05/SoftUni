using System.Collections.Generic;

namespace _1.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().
                                    Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            int maxCapacityOfWagons = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            while (input.ToLower() != "end")
            {
                string[] inputData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = inputData[0];

                if (command.ToLower() == "add")
                {
                    wagons.Add(int.Parse(inputData[1]));
                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] < maxCapacityOfWagons && 
                            wagons[i] + int.Parse(command) <= maxCapacityOfWagons)
                        {
                            wagons[i] = wagons[i] + int.Parse(command);
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', wagons));
        }
    }
}