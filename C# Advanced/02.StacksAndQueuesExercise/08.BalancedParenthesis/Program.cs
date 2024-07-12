namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequenceOfParentheses = Console.ReadLine();
            Stack<char> parenthesStack = new Stack<char>();

            foreach (char symbol in sequenceOfParentheses)
            {
                if (parenthesStack.Any())
                {
                    char check = parenthesStack.Peek();
                    if (check == '{' && symbol == '}')
                    {
                        parenthesStack.Pop();
                        continue;
                    }
                    else if (check == '[' && symbol == ']')
                    {
                        parenthesStack.Pop();
                        continue;
                    }
                    else if (check == '(' && symbol == ')')
                    {
                        parenthesStack.Pop();
                        continue;
                    }
                    else if (check == ' ' && symbol == ' ')
                    {
                        parenthesStack.Pop();
                        continue;
                    }
                }
                parenthesStack.Push(symbol);
            }

            Console.WriteLine(!parenthesStack.Any() ? "YES" : "NO");
        }
    }
}
