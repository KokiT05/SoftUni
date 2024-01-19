using System;

namespace _06.MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = int.MinValue;
            int number = 0;

            string command = Console.ReadLine();
            command = command.ToLower();
            while (command != "stop")
            {
                number = int.Parse(command);
                if (number >= maxNumber)
                {
                    maxNumber = number;
                }

                command = Console.ReadLine();
                command = command.ToLower();
            }

            Console.WriteLine(maxNumber);
        }
    }
}
