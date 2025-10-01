int foodQuantity = int.Parse(Console.ReadLine()!);

int[] orders = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

Queue<int> ordersQueue = new Queue<int>(orders);

int biggestElemet = ordersQueue.Peek();
for (int i = 0; i < orders.Length && ordersQueue.Count > 0; i++)
{
    if (ordersQueue.Peek() > biggestElemet)
    {
        biggestElemet = ordersQueue.Peek();
    }

    if (ordersQueue.Peek() <= foodQuantity)
	{
		foodQuantity -= ordersQueue.Peek();
		ordersQueue.Dequeue();
	}
}

Console.WriteLine(biggestElemet);

if (ordersQueue.Count > 0)
{
    Console.WriteLine($"Orders left: {string.Join(' ', ordersQueue)}");
}
else
{
    Console.WriteLine($"Orders complete");
}