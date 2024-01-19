using System;

namespace _04.Sequence2k_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = 0;

            while (true)
            {
                result = (result * 2) + 1;
                if (result > n)
                {
                    break;
                }
                Console.WriteLine(result);
            }
        }
    }
}
