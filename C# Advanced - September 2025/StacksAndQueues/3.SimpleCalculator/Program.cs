string[] numbers = Console.ReadLine()!.Split().Reverse().ToArray();

Stack<string> stack = new Stack<string>(numbers);

while (stack.Count > 1)
{
    int firstNumber = int.Parse(stack.Pop());
    char operation = char.Parse(stack.Pop());
    int secondNumber = int.Parse(stack.Pop());

    string result = string.Empty;

    if (operation == '+')
    {
        result = (firstNumber + secondNumber).ToString();
    }
    else if (operation == '-')
    {
        result = (firstNumber - secondNumber).ToString();
    }

    stack.Push(result);
}

Console.WriteLine(stack.Peek());

