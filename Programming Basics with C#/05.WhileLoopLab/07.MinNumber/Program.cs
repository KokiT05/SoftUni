using System;

namespace _07.MinNumber
{
        internal class Program
        {
            static void Main(string[] args)
            {
                int minNumber = int.MaxValue;
                int number = 0;

                string command = Console.ReadLine();
                command = command.ToLower();
                while (command != "stop")
                {
                    number = int.Parse(command);
                    if (number <= minNumber)
                    {
                        minNumber = number;
                    }

                    command = Console.ReadLine();
                    command = command.ToLower();
                }

                Console.WriteLine(minNumber);
            }
        }
}
