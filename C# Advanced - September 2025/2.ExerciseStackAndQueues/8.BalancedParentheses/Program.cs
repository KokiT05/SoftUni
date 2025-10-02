string input = Console.ReadLine()!;

int middleIndex = 0;
if (input.Length % 2 != 0)
{
	middleIndex = input.Length / 2;
}

int currentIdex = 0;
Stack<char> balancedParentheses = new Stack<char>();
for (int i = 0; i < input.Length; i++)
{
	if (input[middleIndex] != ' ')
	{
        if ((input[i] == '(') ||
                        (input[i] == '[') ||
                        (input[i] == '{') ||
                        (input[i] == ' '))
        {
            balancedParentheses.Push(input[i]);
        }
		else if(balancedParentheses.Count > 0)
		{
			char currentElement = balancedParentheses.Peek();

            if ((currentElement == '(' && input[i] == ')') ||
                (currentElement == '[' && input[i] == ']') ||
                (currentElement == '{' && input[i] == '}') ||
                (currentElement == ' ' && input[i] == ' '))
            {
                currentIdex = i;
                balancedParentheses.Pop();
            }
        }
    }
}

if (balancedParentheses.Count == 0 && currentIdex == input.Length - 1)
{
    Console.WriteLine("YES");

}
else
{
    Console.WriteLine("NO");
}

//Stack<char> openParentheses;
//Queue<char> closeParentheses;

//int middleIndex = 0;
//if (input.Length % 2 != 0)
//{
//    middleIndex = (input.Length / 2);
//    openParentheses = new Stack<char>(input.Substring(0, (input.Length - middleIndex)));


//    closeParentheses = new Queue<char>(input.Substring(middleIndex, (input.Length - middleIndex)));
//}
//else
//{
//    openParentheses = new Stack<char>(input.Substring(0, input.Length / 2));
//    closeParentheses = new Queue<char>(input.Substring(input.Length / 2, input.Length / 2));
//}

////Console.WriteLine(string.Join(',', openParentheses));
////Console.WriteLine(string.Join(',', closeParentheses));

//while (openParentheses.Count > 0 && closeParentheses.Count > 0)
//{
//    char OpenElement = openParentheses.Peek();
//    char closeElement = closeParentheses.Peek();

//    if ((OpenElement == '(' && closeElement == ')') ||
//        (OpenElement == '[' && closeElement == ']') ||
//        (OpenElement == '{' && closeElement == '}') ||
//        (OpenElement == ' ' && closeElement == ' '))
//    {
//        openParentheses.Pop();
//        closeParentheses.Dequeue();
//    }
//    else
//    {
//        Console.WriteLine($"NO");
//        return;
//    }
//}

//if (openParentheses.Count == 0 && closeParentheses.Count == 0)
//{
//    Console.WriteLine($"YES");
//}
//else
//{
//    Console.WriteLine("NO");
//}