using System;

namespace _07.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isSpaceAvailable = true;
            double totalValueOfCartons = 0;

            double widthOfFreeSpace = double.Parse(Console.ReadLine());
            double lengthOfFreeSpace = double.Parse(Console.ReadLine());
            double heightOfFreeSpace = double.Parse(Console.ReadLine());

            double volumeOfFreeSpace = widthOfFreeSpace * lengthOfFreeSpace * heightOfFreeSpace;

            string command = Console.ReadLine();
            command.ToLower();

            while (command != "done")
            {
                totalValueOfCartons += double.Parse(command);

                if (totalValueOfCartons >= volumeOfFreeSpace)
                {
                    isSpaceAvailable = false;
                    break;
                }

                command = Console.ReadLine();
                command = command.ToLower();
            }

            double freeSpace = Math.Abs(volumeOfFreeSpace - totalValueOfCartons);

            if (isSpaceAvailable)
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {freeSpace} Cubic meters more.");
            }
        }
    }
}
