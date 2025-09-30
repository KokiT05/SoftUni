int[] numbers = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

Queue<int> queue = new Queue<int>(numbers);

int number = 0;
for (int i = 0; i < numbers.Length; i++)
{
    number = queue.Dequeue();

    if (number % 2 == 0)
	{
		queue.Enqueue(number);
	}
}

Console.WriteLine(string.Join(", ", queue));