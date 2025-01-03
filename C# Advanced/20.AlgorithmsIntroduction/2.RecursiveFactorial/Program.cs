﻿namespace _2.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long factorial = Factorial(n);
            Console.WriteLine($"Recursion factorial: {factorial}");
        }

        public static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
