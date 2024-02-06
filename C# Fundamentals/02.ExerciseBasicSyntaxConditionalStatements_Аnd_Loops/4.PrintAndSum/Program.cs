using System;

namespace _4.PrintAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                sum += i;
                Console.Write($"{i} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
