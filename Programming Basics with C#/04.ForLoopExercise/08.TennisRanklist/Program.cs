using System;
using System.ComponentModel;
using System.Data.Common;

namespace _08.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double W = 2000;
            double F = 1200;
            double SF = 720;
            double totalPoints = 0;
            double Wtournamets = 0;

            int numberOfTournaments = int.Parse(Console.ReadLine());
            double startingNumberOfPoints = double.Parse(Console.ReadLine());
            totalPoints = totalPoints + startingNumberOfPoints;
            for (int i = 1; i <= numberOfTournaments; i++)
            {
                string result = Console.ReadLine();
                result = result.ToLower();
                if (result == "w")
                {
                    totalPoints = totalPoints + W;
                    Wtournamets++;
                }
                else if (result == "f")
                {
                    totalPoints = totalPoints + F;
                }
                else if (result == "sf")
                {
                    totalPoints = totalPoints + SF;
                }
            }

            Console.WriteLine($"Final points: {totalPoints}");
            totalPoints -= startingNumberOfPoints;
            double averagePoints = Math.Floor(totalPoints / numberOfTournaments);
            Console.WriteLine($"Average points: {averagePoints}");
            Console.WriteLine($"{((Wtournamets / numberOfTournaments) * 100):f2}%");

        }
    }
}
