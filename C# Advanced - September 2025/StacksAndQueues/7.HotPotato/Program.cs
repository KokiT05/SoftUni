string[] children = Console.ReadLine()!.Split();
int n = int.Parse(Console.ReadLine()!);

Queue<string> hotPatato = new Queue<string>(children);

while (hotPatato.Count > 1)
{
	for (int i = 1; i < n; i++)
	{
		hotPatato.Enqueue(hotPatato.Dequeue());
	}

	Console.WriteLine($"Removed {hotPatato.Dequeue()}");
}

Console.WriteLine($"Last is {hotPatato.Peek()}");