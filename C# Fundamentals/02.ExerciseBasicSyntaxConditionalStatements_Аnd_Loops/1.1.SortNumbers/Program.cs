using System;

namespace _1._1.SortNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 3; i++)
            {
                if (firstNumber >= secondNumber && firstNumber >= thirdNumber)
                {
                    Console.WriteLine(firstNumber);
                    firstNumber = int.MinValue;
                }
                else if (secondNumber >= thirdNumber && secondNumber >= firstNumber)
                {
                    Console.WriteLine(secondNumber);
                    secondNumber = int.MinValue;
                }
                else if (thirdNumber >= firstNumber && thirdNumber >= secondNumber)
                {
                    Console.WriteLine(thirdNumber);
                    thirdNumber = int.MinValue;
                }
            }
        }
    }
}
