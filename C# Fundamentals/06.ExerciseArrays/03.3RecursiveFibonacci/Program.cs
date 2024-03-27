namespace _03._3RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(SolveMemoization(n));
            //FibonachiRecursion(n);
            //Console.WriteLine(n);
        }

        public static double SolveMemoization(int n)
        {
            double result;
            if (memo.ContainsKey(n))
            {
                result = memo[n];
            }
            else
            {
                result = SolveMemoization(n - 1) + SolveMemoization(n - 2);
                memo[n] = result;
            }
            return result;

        }

        static Dictionary<int, double> memo = new Dictionary<int, double>() {
            {1, 1},
            {2, 1}
        };

        //static long FibonachiRecursion(int n)
        //{
        //    if (n <= 2)
        //    {
        //        return 1;
        //    }
        //    return FibonachiRecursion(n - 1) + FibonachiRecursion(n - 2);
        //}
    }
}