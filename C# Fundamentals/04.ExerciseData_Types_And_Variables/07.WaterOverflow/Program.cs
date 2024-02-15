using System;

namespace _07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tankCapacity = 255;
            double sumOfWater = 0;

            double litersOfWater = 0;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                litersOfWater = double.Parse(Console.ReadLine());
                if (tankCapacity < (sumOfWater + litersOfWater))
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    sumOfWater += litersOfWater;
                }

            }

            Console.WriteLine(sumOfWater);
        }
    }
}
