int bulletPrice = int.Parse(Console.ReadLine()!);
int sizeGunBarrel =  int.Parse(Console.ReadLine()!);
int[] bullets = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
int[] locks = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
int intelligenceValue = int.Parse(Console.ReadLine()!);

Queue<int> queueLocks = new Queue<int>(locks);
Stack<int> stackBullets =  new Stack<int>(bullets);

int bulletsFired = 0;
while (queueLocks.Count > 0 && stackBullets.Count > 0)
{
    int bullet = stackBullets.Pop();
    int @lock = queueLocks.Peek();

    bulletsFired++;

    if (bullet <= @lock)
    {
        queueLocks.Dequeue();
        Console.WriteLine($"Bang!");
    }
    else
    {
        Console.WriteLine("Ping!");
    }

    if (bulletsFired % sizeGunBarrel == 0 && stackBullets.Count > 0)
    {
        Console.WriteLine("Reloading!");
    }
}

int bulletsPriceSum = bulletsFired * bulletPrice;

if (queueLocks.Count > 0)
{
    Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
}
else
{
    Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${intelligenceValue - bulletsPriceSum}");
}