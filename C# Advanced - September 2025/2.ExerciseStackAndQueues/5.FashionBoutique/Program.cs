int[] clothesBox = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

Stack<int> stack = new Stack<int>(clothesBox);

int capacityRack = int.Parse(Console.ReadLine()!);

int clothingSum = 0;
int numbersRack = 0;

//if (stack.Count > 0 && capacityRack > 0)
//{
//	numbersRack = 1;

//}


for (int i = 0; i < clothesBox.Length; i++)
{
	clothingSum += stack.Peek();

	if (clothingSum == capacityRack)
	{
		numbersRack++;
		clothingSum = 0;
	}
	else if (clothingSum > capacityRack)
	{
		numbersRack++;
		clothingSum = stack.Peek();
	}

    stack.Pop();

}

if (clothingSum > 0)
{
	numbersRack++;
}

Console.WriteLine(numbersRack);

