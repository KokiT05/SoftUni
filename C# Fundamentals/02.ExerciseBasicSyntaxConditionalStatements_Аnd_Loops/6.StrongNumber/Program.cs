using System;
using System.Xml;

namespace _6.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumOfFactorials = 0;
            int numberFactorial = 1;

            string numberInString = Console.ReadLine();
            int numberInInt = int.Parse(numberInString);
            for (int i = 0; i < numberInString.Length; i++)
            {
                int number = int.Parse(numberInString[i].ToString());

                numberFactorial = 1;
                for (int j = number; j >= 1; j--)
                {
                    numberFactorial = numberFactorial * j;
                }
                sumOfFactorials += numberFactorial;
            }

            if (sumOfFactorials == numberInInt)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
