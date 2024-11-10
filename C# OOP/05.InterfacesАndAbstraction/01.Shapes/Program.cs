namespace _01.Shapes // Shapes
{
    internal class Program // StartUp
    {
        static void Main(string[] args)
        {
            int radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);
            circle.Draw();

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            IDrawable rectangle = new Rectangle(width, height);
            rectangle.Draw();
        }
    }
}
