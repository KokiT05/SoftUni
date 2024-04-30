using System.Numerics;

namespace _2.BigFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger bigInteger = 1;

            for (int i = 2; i <= n; i++)
            {
                bigInteger *= i;
            }

            Console.WriteLine(bigInteger);
        }
    }
}