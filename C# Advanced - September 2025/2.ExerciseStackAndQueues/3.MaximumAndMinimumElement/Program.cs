int n = int.Parse(Console.ReadLine()!);

Stack<int> stack = new Stack<int>();

for (int i = 1; i <= n; i++)
{
    int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

    int command = input[0];

    if (command == 1)
    {
        stack.Push(input[1]);
    }
    else if (command == 2 && stack.Count > 0)
    {
        stack.Pop();
    }
    else if (command == 3 && stack.Count > 0)
    {
        Console.WriteLine(stack.Max());
    }
    else if (command == 4 && stack.Count > 0)
    {
        Console.WriteLine(stack.Min());
    }
}

if (stack.Count > 0)
{
    Console.WriteLine(string.Join(", ", stack));
}