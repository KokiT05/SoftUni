using System.Reflection.Metadata.Ecma335;

namespace _11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            double secondNumber = double.Parse(Console.ReadLine());

            double result = MathOperations(firstNumber, secondNumber, symbol);
            Console.WriteLine(result);
        }

        static double MathOperations(double firstNumber, double secondNumber, string symbol)
        {
            double result = 0;

            if (symbol == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (symbol == "-")
            {
                result = firstNumber - secondNumber;
            }
            else if (symbol == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if (symbol == "/")
            {
                result = firstNumber / secondNumber;
            }

            return result;
        }
    }
}