using System;
using System.Threading;

namespace _06._6.BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int leftBrackets = 0;
            int rightBrackets = 0;

            bool isBalanced = false;

            string lastBrackets = string.Empty;
            string currentBrackets = string.Empty;

            for (int i = 1; i <= n; i++)
            {
                string character = Console.ReadLine();

                if (character == "(")
                {
                    leftBrackets++;
                    currentBrackets = character;
                }
                else if (character == ")")
                {
                    rightBrackets++;
                    currentBrackets = character;
                }

                if (Math.Abs(leftBrackets - rightBrackets) != 0)
                {
                    isBalanced = false;
                }
                else if ((leftBrackets - rightBrackets) == 0)
                {
                    isBalanced = true;
                }

                if (character == "(" || character == ")")
                {
                    if (lastBrackets == currentBrackets)
                    {
                        isBalanced = false;
                        break;
                    }
                }

                lastBrackets = currentBrackets;
            }

            if (isBalanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
