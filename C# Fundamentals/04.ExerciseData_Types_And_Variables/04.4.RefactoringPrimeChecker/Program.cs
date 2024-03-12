using System;

namespace _04._4.RefactoringPrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i++)
            {

                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {

                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                string output = $"{i} -> {isPrime}";
                Console.WriteLine(output.ToLower());
            }
        }
    }
}
