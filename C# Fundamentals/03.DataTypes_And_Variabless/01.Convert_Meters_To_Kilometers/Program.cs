using System;

namespace _01.Convert_Meters_To_Kilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float meters = float.Parse(Console.ReadLine());

            float kilometers = meters / 1000.0F;

            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
