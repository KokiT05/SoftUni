using System;

namespace _06.WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeinSecondsForOneMeter = double.Parse(Console.ReadLine());

            double waterResistance = 12.5;
            double delay = waterResistance * Math.Floor((distanceInMeters / 15));
            double totalTime = (timeinSecondsForOneMeter * distanceInMeters) + delay;

            double result = Math.Abs(totalTime - recordInSeconds);
            if (recordInSeconds > totalTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {result:f2} seconds slower.");
            }
        }
    }
}
