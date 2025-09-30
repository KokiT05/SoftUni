int[] numbers = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

int[] inputNumbers = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

int enqueueNumbers = numbers[0];
int dequeueNumbers = numbers[1];
int keyNumber = numbers[2];

Queue<int> queue = new Queue<int>();

for (int i = 0; i < enqueueNumbers; i++)
{
    queue.Enqueue(inputNumbers[i]);
}

for (int i = 1; i <= dequeueNumbers && queue.Count > 0; i++)
{
    queue.Dequeue();
}

if (queue.Count == 0)
{
    Console.WriteLine(0);
    return;
}

int smallestElement = queue.Peek();
bool isFound = false;

while (queue.Count > 0)
{
    if (smallestElement > queue.Peek())
    {
        smallestElement = queue.Peek();
    }

    if (keyNumber == queue.Peek())
    {
        isFound = true;
        Console.WriteLine("true");
        return;
    }

    queue.Dequeue();
}

if (isFound == false)
{
    Console.WriteLine(smallestElement);
}