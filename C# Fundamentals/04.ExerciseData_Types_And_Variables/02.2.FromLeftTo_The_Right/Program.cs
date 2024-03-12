using System;

namespace _02._2.FromLeftTo_The_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                int spaceIndex = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == ' ')
                    {
                        spaceIndex = j;
                    }
                }

                long leftNumber = long.Parse(input.Substring(0, spaceIndex));
                long rightNumber = long.Parse(input.Substring(spaceIndex + 1));

                long leftNumberSumDigits = 0;
                while (leftNumber != 0)
                {
                    leftNumberSumDigits += leftNumber % 10;
                    leftNumber = leftNumber / 10;
                }

                long RightNumberSumDigits = 0;
                while (rightNumber != 0)
                {
                    RightNumberSumDigits += rightNumber % 10;
                    rightNumber = rightNumber / 10;
                }

                if (RightNumberSumDigits >= leftNumberSumDigits)
                {
                    Console.WriteLine(RightNumberSumDigits);
                }
                else
                {
                    Console.WriteLine(leftNumberSumDigits);
                }
            }
        }
    }
}
