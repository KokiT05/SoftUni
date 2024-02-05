using System;

namespace _11.MultiplicationTable_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (secondNumber <= 10)
            {
                for (int i = secondNumber; i <= 10; i++)
                {
                    result = firstNumber * i;
                    Console.WriteLine($"{firstNumber} X {i} = {result}");
                }
            }
            else
            {
                result = firstNumber * secondNumber;
                Console.WriteLine($"{firstNumber} X {secondNumber} = {result}");
            }
        }
    }
}
