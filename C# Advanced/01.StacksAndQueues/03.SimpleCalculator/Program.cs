using System.Linq.Expressions;

namespace _03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] simpleExpression = Console.ReadLine().Split().Reverse().ToArray();

            Stack<string> expressionStack = new Stack<string>(simpleExpression);

            while (expressionStack.Count > 1)
            {
                int firstNumber = int.Parse(expressionStack.Pop());
                string symbol = expressionStack.Pop();
                int secondNumber = int.Parse(expressionStack.Pop());

                if (symbol == "+")
                {
                    expressionStack.Push((firstNumber + secondNumber).ToString());
                }
                else if (symbol == "-")
                {
                    expressionStack.Push((firstNumber - secondNumber).ToString());
                }
            }

            Console.WriteLine(expressionStack.Pop());
        }
    }
}
