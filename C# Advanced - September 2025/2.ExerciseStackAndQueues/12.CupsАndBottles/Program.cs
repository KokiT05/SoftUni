int[] cups = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
int[] bottles = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

Queue<int> queueCups = new Queue<int>(cups);
Stack<int> stackBottles = new Stack<int>(bottles);

int wastedWater = 0;
int currentCupCapacity = 0;

while (queueCups.Count > 0 && stackBottles.Count > 0)
{
    int currentCup = queueCups.Peek();
    int currentBottle = stackBottles.Peek();

    if (currentBottle >= currentCup)
    {
        wastedWater += currentBottle -= currentCup;
        queueCups.Dequeue();
        stackBottles.Pop();
    }
    else
    {
        currentCupCapacity = currentCup;

        //!!!
        while (currentCupCapacity > 0 && stackBottles.Count > 0)
        {
            currentCupCapacity -= stackBottles.Pop();
        }

        if (currentCupCapacity < 0)
        {
            wastedWater += (currentCupCapacity * -1);
            queueCups.Dequeue();
        }
        else if (currentCupCapacity == 0)
        {
            queueCups.Dequeue();
        }
    }
}

if (stackBottles.Count > 0)
{
    Console.WriteLine($"Bottles: {string.Join(' ', stackBottles)}");
}
else if (queueCups.Count > 0)
{
    Console.WriteLine($"Cups: {string.Join(' ', queueCups)}");
}

Console.WriteLine($"Wasted litters of water: {wastedWater}");