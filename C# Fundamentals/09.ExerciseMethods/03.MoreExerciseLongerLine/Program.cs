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

            double[] firstPoit = ClosestToCenter(firstPoitX1, firstPoitY1, firstPoitX2, firstPoitY2);
            double[] secondPoit = ClosestToCenter(secondPoitX1, secondPoitY1, secondPoitX2, secondPoitY2);

            double firstPoitResult = Math.Sqrt(Math.Pow((firstPoitX2 - firstPoitX1), 2) +
                                        Math.Pow((firstPoitY2 - firstPoitY1), 2));

            double secondPoitResult = Math.Sqrt(Math.Pow((secondPoitX2 - secondPoitX1), 2) +
                            Math.Pow((secondPoitY2 - secondPoitY1), 2));

            if (firstPoitResult >= secondPoitResult)
            {
                Console.WriteLine($"({firstPoit[0]}, {firstPoit[1]})({firstPoit[2]}, {firstPoit[3]})");
            }
            else
            {
                Console.WriteLine($"({secondPoit[0]}, {secondPoit[1]})({secondPoit[2]}, {secondPoit[3]})");
            }
        }

        static double[] ClosestToCenter(double x1, double y1, double x2, double y2)
        {
            double[] poits = new double[4];

            double firstPoint = Math.Pow(x1, 2) + Math.Pow(y1, 2);
            double secondPoit = Math.Pow(x2, 2) + Math.Pow(y2, 2);

            if (firstPoint <= secondPoit)
            {
                poits[0] = x1;
                poits[1] = y1;
                poits[2] = x2;
                poits[3] = y2;

                return poits;
            }

            poits[0] = x2;
            poits[1] = y2;
            poits[2] = x1;
            poits[3] = y1;

            return poits;
        }
    }
}