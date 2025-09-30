string input = Console.ReadLine()!;

Stack<int> brackets = new Stack<int>();

int lastOpenBracketIndex = 0;

for (int i = 0; i < input.Count(); i++)
{
	if (input[i] == '(')
	{
		brackets.Push(i);
	}
	else if (input[i] == ')' && brackets.Count > 0)
	{
		lastOpenBracketIndex = brackets.Pop();
        Console.WriteLine(input.Substring(lastOpenBracketIndex, (i - lastOpenBracketIndex + 1)));
    }
}