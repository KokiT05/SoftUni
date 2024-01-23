using System;
using System.Net.NetworkInformation;

namespace _06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isLeftCake = true;

            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());

            double cakeS = width * length;

            string pieceSize = Console.ReadLine();

            while (pieceSize != "STOP")
            {
                cakeS -= double.Parse(pieceSize);

                if (cakeS < 0)
                {
                    isLeftCake = false;
                    break;
                }

                pieceSize = Console.ReadLine();
            }

            if (isLeftCake)
            {
                Console.WriteLine($"{cakeS} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakeS)} pieces more.");
            }
        }
    }
}
