using System;

namespace _09.FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double precentage = double.Parse(Console.ReadLine());
            precentage = precentage / 100;

            double volume = (length * width) * height;
            volume = volume * 0.001;

            double totalVolume = volume * (1 - precentage);

            Console.WriteLine(totalVolume);
        }
    }
}
