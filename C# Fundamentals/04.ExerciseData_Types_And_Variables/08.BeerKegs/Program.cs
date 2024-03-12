using System;

namespace _08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string model = string.Empty;
            double radius = 0.0;//double.Parse(Console.ReadLine());
            int height = 0;//int.Parse(Console.ReadLine());
            double volume = 0;
            double maxVolume = 0;
            string biggestKeg = string.Empty;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                model = Console.ReadLine();
                radius = double.Parse(Console.ReadLine());
                height = int.Parse(Console.ReadLine());

                volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume >= maxVolume)
                {
                    maxVolume = volume;
                    biggestKeg = model;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
