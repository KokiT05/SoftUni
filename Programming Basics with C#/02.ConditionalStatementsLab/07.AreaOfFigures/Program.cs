using System;

namespace _07.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            double S = 0;

            if (type == "square")
            {
                double a = double.Parse(Console.ReadLine());
                S = a * a;
            }
            else if (type == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                S = a * b;
            }
            else if (type == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                S = Math.PI * (r * r);
            }
            else if (type == "triangle")
            {
                double c = double.Parse((Console.ReadLine()));
                double h = double.Parse(((Console.ReadLine())));
                S = (c * h) / 2;
            }

            Console.WriteLine($"{S:f3}");
        }
    }
}
