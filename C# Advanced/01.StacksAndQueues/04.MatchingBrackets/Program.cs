using System.Linq.Expressions;

namespace _04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string arithmeticExpression = Console.ReadLine();

            Stack<int> index = new Stack<int>();
            for (int i = 0; i < arithmeticExpression.Length; i++)
            {
                if (arithmeticExpression[i] == '(')
                {
                    index.Push(i);
                }
                else if (arithmeticExpression[i] == ')')
                {
                    int closingBracket = i;
                    int openingBracket = index.Pop();

                    Console
                    .WriteLine
                    (arithmeticExpression.Substring(openingBracket, closingBracket - openingBracket + 1));
                }
            }
        }
    }
}
