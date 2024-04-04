namespace _02.MoreExercisCenterPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstX = double.Parse(Console.ReadLine());
            double firstY = double.Parse(Console.ReadLine());
            double secondX = double.Parse(Console.ReadLine());
            double secondY = double.Parse(Console.ReadLine());

            string result = ClosestToCenter(firstX, firstY, secondX, secondY);
            Console.WriteLine(result);


        }

        static string ClosestToCenter(double x1, double y1, double x2, double y2)
        {
            string poits = "(";

            double firstPoint = Math.Pow(x1, 2) + Math.Pow(y1, 2);
            double secondPoit = Math.Pow(x2, 2) + Math.Pow(y2, 2);

            if (firstPoint <= secondPoit)
            {
                poits += x1 + ", " + y1 + ")";
                return poits;
            }
            else
            {
                poits += x2 + ", " + y2 + ")";
            }

            return poits;
        }
    }
}