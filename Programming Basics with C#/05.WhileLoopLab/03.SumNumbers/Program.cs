using System;

namespace _03.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = 0;
            int sum = 0;
            while (true)
            {
                number = int.Parse(Console.ReadLine());
                sum += number;

                if (sum >= n)
                {
                    break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
