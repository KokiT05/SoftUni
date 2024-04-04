namespace _03.MoreExerciseLongerLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstPoitX1 = double.Parse(Console.ReadLine());
            double firstPoitY1 = double.Parse(Console.ReadLine());
            double firstPoitX2 = double.Parse(Console.ReadLine());
            double firstPoitY2 = double.Parse(Console.ReadLine());

            double secondPoitX1 = double.Parse(Console.ReadLine());
            double secondPoitY1 = double.Parse(Console.ReadLine());
            double secondPoitX2 = double.Parse(Console.ReadLine());
            double secondPoitY2 = double.Parse(Console.ReadLine());

            double firstPointLine = ClosestToCenter(firstPoitX1, firstPoitY1, firstPoitX2, firstPoitY2);
            double secondPointLine = ClosestToCenter(secondPoitX1, secondPoitY1, secondPoitX2, secondPoitY2);

            if (firstPointLine >= secondPointLine)
            {
                Console.WriteLine($"({firstPoitX1}, {firstPoitY1} ({firstPoitX2}, {firstPoitY2})");
            }
            else
            {
                Console.WriteLine($"({secondPoitX1}, {secondPoitY1} ({secondPoitX2}, {secondPoitY2})");
            }
        }

        static double ClosestToCenter(double x1, double y1, double x2, double y2)
        {
            double poits = 0;

            double firstPoint = Math.Pow(x1, 2) + Math.Pow(y1, 2);
            double secondPoit = Math.Pow(x2, 2) + Math.Pow(y2, 2);

            poits = firstPoint + secondPoit;

            return poits;
        }
    }
}