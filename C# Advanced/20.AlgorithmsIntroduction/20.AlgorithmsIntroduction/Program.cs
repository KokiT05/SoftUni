namespace _20.AlgorithmsIntroduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Fibonacci recursion
            //int n = 3;
            //Console.WriteLine($"Fibonacci({n}) = {Fibonacci(n)}");

            //Recursion
        }

        public static int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
