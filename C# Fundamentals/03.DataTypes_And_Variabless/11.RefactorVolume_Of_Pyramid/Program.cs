using System;

namespace _11.RefactorVolume_Of_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length = 0.0;
            double width = 0.0;
            double heigth = 0.0;
            double V = 0.0;

            Console.Write("Length: ");

            length = double.Parse(Console.ReadLine());

            Console.Write("Width: ");

            width = double.Parse(Console.ReadLine());

            Console.Write("Height: ");

            heigth = double.Parse(Console.ReadLine());

            V = 1/3.0 * ((width * length) * heigth);

            Console.WriteLine($"Pyramid Volume: {V:f2}");
        }
    }
}
