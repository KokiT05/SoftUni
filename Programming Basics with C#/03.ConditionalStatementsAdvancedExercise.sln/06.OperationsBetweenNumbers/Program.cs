using System;

namespace _06.OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();

            double result = 0;
            string everOrOdd = string.Empty;
            if (@operator == "+" || @operator == "-" || @operator == "*")
            {
                if (@operator == "+")
                {
                    result = firstNumber + secondNumber;
                }
                else if (@operator == "-")
                {
                    result = firstNumber - secondNumber;
                }
                else if (@operator == "*")
                {
                    result = firstNumber * secondNumber;
                }

                if (result % 2 == 0)
                {
                    everOrOdd = "even";
                }
                else
                {
                    everOrOdd = "odd";
                }
                
                Console.WriteLine($"{firstNumber} {@operator} {secondNumber} = {result} - {everOrOdd}");
            }
            else if (@operator == "/")
            {
                if (secondNumber != 0)
                {
                    result = ((double)firstNumber / secondNumber);
                    Console.WriteLine($"{firstNumber} / {secondNumber} = {result:f2}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {firstNumber} by zero");
                }
            }
            else if (@operator == "%")
            {
                if (secondNumber != 0)
                {
                    result = firstNumber % secondNumber;
                    Console.WriteLine($"{firstNumber} % {secondNumber} = {result}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {firstNumber} by zero");
                }
            }
        }
    }
}
