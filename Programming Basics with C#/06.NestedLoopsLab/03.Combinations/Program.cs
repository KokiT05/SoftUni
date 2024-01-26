using System;

namespace _03.Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int validCombinationsCount = 0;

            int n = int.Parse(Console.ReadLine());

            for (int firstX = 0; firstX <= n ; firstX++)
            {
                for (int secondX = 0; secondX <= n; secondX++)
                {
                    for (int thirdX = 0; thirdX <= n; thirdX++)
                    {
                        if ((firstX + secondX + thirdX) == n)
                        {
                            validCombinationsCount++;
                        }
                    }
                }
            }

            Console.WriteLine(validCombinationsCount);
        }
    }
}
