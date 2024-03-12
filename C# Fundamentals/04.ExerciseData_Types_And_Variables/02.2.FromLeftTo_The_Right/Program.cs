using System;
using System.Numerics;

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

                BigInteger leftNumber = BigInteger.Parse(input.Substring(0, spaceIndex));
                BigInteger rightNumber = BigInteger.Parse(input.Substring(spaceIndex + 1));

                if (leftNumber > rightNumber)
                {
                    BigInteger leftNumberSumDigits = 0;
                    while (leftNumber != 0)
                    {
                        if (leftNumber < 0)
                        {
                            leftNumberSumDigits -= leftNumber % 10;
                            leftNumber = leftNumber / 10;
                        }
                        else
                        {
                            leftNumberSumDigits += leftNumber % 10;
                            leftNumber = leftNumber / 10;
                        }
                    }

                    Console.WriteLine(leftNumberSumDigits);
                }
                else
                {
                    BigInteger RightNumberSumDigits = 0;
                    while (rightNumber != 0)
                    {

                        if (rightNumber < 0)
                        {
                            RightNumberSumDigits -= rightNumber % 10;
                            rightNumber = rightNumber / 10;
                        }
                        else
                        {
                            RightNumberSumDigits += rightNumber % 10;
                            rightNumber = rightNumber / 10;
                        }
                    }
                    Console.WriteLine(RightNumberSumDigits);
                }
            }
        }
    }
}
