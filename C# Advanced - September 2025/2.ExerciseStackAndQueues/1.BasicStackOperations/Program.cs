int[] numbers = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

int pushNumbers = numbers[0];
int popNumbers = numbers[1];
int keyNumber = numbers[2];

Stack<int> stack = new Stack<int>();

int[] inputNumbers = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
for (int i = 0; i < pushNumbers; i++)
{
	stack.Push(inputNumbers[i]);
}

for (int i = 1; i <= popNumbers && stack.Count > 0; i++)
{
	stack.Pop();
}

if (stack.Count == 0)
{
    Console.WriteLine(0);
    return;
}

int smallestElemet = stack.Peek();
bool isFound = false;

while (stack.Count > 0)
{
    if (smallestElemet > stack.Peek())
    {
        smallestElemet = stack.Peek();
    }

    if (stack.Peek() == keyNumber)
    {
        isFound = true;
        Console.WriteLine("true");
        break;
    }

    stack.Pop();
}

if (isFound == false)
{
    Console.WriteLine(smallestElemet);
}

//bool isFound = stack.Contains(keyNumber);

//if (stack.Count == 0)
//{
//    Console.WriteLine(0);
//}
//else if (isFound)
//{
//    Console.WriteLine(isFound.ToString().ToLower());
//}
//else
//{
//    Console.WriteLine(stack.Min());
//}