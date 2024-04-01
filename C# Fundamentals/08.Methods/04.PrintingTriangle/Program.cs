namespace _04.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangleTop(n);
            PrintTriangleFloor(n);
        }

        static void PrintTriangleTop(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                PrintTriangleRowValue(i);
                Console.WriteLine();
            }
        }

        static void PrintTriangleFloor(int n)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                PrintTriangleRowValue(i);
                Console.WriteLine();
            }
        }

        static void PrintTriangleRowValue(int n)
        {
            for (int j = 1; j <= n; j++)
            {
                Console.Write($"{j} ");
            }
        }
    }
}