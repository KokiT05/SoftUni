using System;
using System.Linq;
using System.Security.Cryptography;

namespace _10.LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());

            int[] indexes = Console
                            .ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int[] field = new int[sizeOfField];
            for (int i = 0; i < sizeOfField; i++)
            {
                field[i] = 0;
            }

            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] >= 0 && indexes[i] < field.Length)
                {
                    field[indexes[i]] = 1;
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end" && field.Length > 0)
            {
                string[] commandParts = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int ladybugIndex = int.Parse(commandParts[0]);
                string direction = commandParts[1];
                int flyLength = int.Parse(commandParts[2]);

                bool inRange = ladybugIndex >= 0 && ladybugIndex < field.Length;
                if (!inRange)
                {
                    continue;
                }

                bool hasLadyBug = field[ladybugIndex] == 1;
                if (!hasLadyBug)
                {
                    continue;
                }

                int newPosition = 0;
                if (direction == "right")
                {
                    if (ladybugIndex + flyLength >= field.Length || ladybugIndex + flyLength < 0)
                    {
                        field[ladybugIndex] = 0;
                    }
                    else if (field[ladybugIndex + flyLength] == 0)
                    {
                        field[ladybugIndex] = 0;
                        field[ladybugIndex + flyLength] = 1;
                    }
                    else
                    {
                        field[ladybugIndex] = 0;
                        newPosition = ladybugIndex + flyLength;
                        for (int i = newPosition; i >= 0 && i < field.Length;)
                        {
                            if (field[i] == 0)
                            {
                                field[i] = 1;
                                break;
                            }
                            else
                            {
                                i = i + flyLength;
                            }
                        }
                    }
                }
                else if (direction == "left") 
                {
                    if (ladybugIndex - flyLength < 0 || ladybugIndex - flyLength >= field.Length)
                    {
                        field[ladybugIndex] = 0;
                    }
                    else if (field[ladybugIndex - flyLength] == 0)
                    {
                        field[ladybugIndex] = 0;
                        field[ladybugIndex - flyLength] = 1;
                    }
                    else
                    {
                        field[ladybugIndex] = 0;
                        newPosition = ladybugIndex - flyLength;
                        for (int i = newPosition; i >= 0 && i < field.Length;)
                        {
                            if (field[i] == 0)
                            {
                                field[i] = 1;
                                break;
                            }
                            else
                            {
                                i = i - flyLength;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(' ', field));
        }
    }
}
