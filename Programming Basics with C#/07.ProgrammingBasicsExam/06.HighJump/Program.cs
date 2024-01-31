using System;
using System.Security;
using System.Threading;

namespace _06.HighJump
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOver = false;

            int numberOfHops = 0;
            double currentHeight = 0;
            double height = 0;

            int failedAttempts = 0;

            double desiredHeight = double.Parse(Console.ReadLine());
            currentHeight = desiredHeight - 30;

            while (currentHeight <= desiredHeight)
            {
                height = double.Parse(Console.ReadLine());
                numberOfHops++;
                if (height <= currentHeight)
                {
                   failedAttempts++;
                }
                else
                {
                    currentHeight += 5;
                }

                if (failedAttempts >= 3)
                {
                    isOver = true;
                    break;
                }
            }

            if (isOver)
            {
                Console.WriteLine($"Tihomir failed at {currentHeight}cm " +
                    $"after {numberOfHops} jumps.");
            }
            else
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {desiredHeight}cm " +
                    $"after {numberOfHops} jumps.");
            }
        }
    }
}
