string input = Console.ReadLine()!;

Stack<char> balancedParentheses = new Stack<char>(input.Substring(0, input.Length / 2));
int startIndex = 0;
if (input.Length % 2 == 0)
{
    startIndex = input.Length / 2;
}
else
{
    startIndex = (input.Length / 2) + 1;
}

for (int i = startIndex; i <= input.Length && balancedParentheses.Count > 0; i++)
{
    char currentElement = balancedParentheses.Peek();
    char currentElemetInput = input[i];

    if (currentElement == '(' && currentElemetInput == ')' ||
        currentElement == '[' && currentElemetInput == ']' ||
        currentElement == '{' && currentElemetInput == '}' ||
        currentElement == ' ' && currentElemetInput == ' ')
    {
        balancedParentheses.Pop();
    }
    else
    {
        Console.WriteLine($"NO");
        break;
    }
}

if (balancedParentheses.Count == 0)
{
    Console.WriteLine($"YES");
}