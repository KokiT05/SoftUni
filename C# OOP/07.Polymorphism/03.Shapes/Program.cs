﻿namespace _03.Shapes // Shapes
{
    internal class Program // StartUp
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            Shape rectangle = new Rectangle(height, width);
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());

            double radius = double.Parse(Console.ReadLine());
            Shape circle = new Circle(radius);
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());
        }
    }
}
