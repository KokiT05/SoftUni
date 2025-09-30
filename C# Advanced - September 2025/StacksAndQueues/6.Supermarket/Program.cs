Queue<string> customers = new Queue<string>();

string command = Console.ReadLine()!;
while (command.ToLower() != "end")
{
	if (command.ToLower() == "paid")
	{
		while (customers.Count > 0)
		{
            Console.WriteLine(customers.Dequeue());
        }
	}
	else
	{
		customers.Enqueue(command);
	}

    command = Console.ReadLine()!;
}

Console.WriteLine($"{customers.Count} people remaining.");