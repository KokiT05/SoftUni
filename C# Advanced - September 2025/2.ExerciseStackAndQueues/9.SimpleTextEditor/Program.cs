using System.Text;

int n = int.Parse(Console.ReadLine()!);

StringBuilder text = new StringBuilder();
Stack<string> operations = new Stack<string>();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()!.Split();
    int command = int.Parse(input[0]);

    if (command == 1)
    {
        if (operations.Count > 0)
        {
            text.Append(operations.Peek());
        }

        text.Append(input[1]);

        operations.Push(text.ToString());
    }
    else if (command == 2 && operations.Count > 0)
    {
        int count = int.Parse(input[1]);
        text.Append(operations.Peek());
        text.Remove(text.Length - count, count);

        operations.Push(text.ToString());
    }
    else if (command == 3 && operations.Count > 0)
    {
        int index = int.Parse(input[1]) - 1;

        text.Append(operations.Peek());

        if (index <= text.Length)
        {

            Console.WriteLine(text[index]);
        }

    }
    else if (command == 4)
    {
        operations.Pop();
    }

    text.Clear();
}

