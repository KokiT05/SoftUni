int[] numbers = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();

Stack<int> stackNumbers = new Stack<int>(numbers);

//foreach (var number in numbers)
//{
//    stackNumbers.Push(number);
//}

string[] commands = Console.ReadLine().Split(' ');

string command = commands[0].ToLower();
int firstNumber = 0;

while (command != "end")
{
    if (command == "add")
    {
        firstNumber = int.Parse(commands[1]);
        int secondNumber = int.Parse(commands[2]);

        stackNumbers.Push(firstNumber);
        stackNumbers.Push(secondNumber);
    }
    else if (command == "remove")
    {
        firstNumber = int.Parse(commands[1]);

        if (firstNumber <= stackNumbers.Count)
        {

            for (int i = 0; i < firstNumber; i++)
            {
                stackNumbers.Pop();
            }
        }
    }

    commands = Console.ReadLine()!.Split(' ');
    command = commands[0].ToLower();
}

Console.WriteLine($"Sum: {stackNumbers.Sum()}");