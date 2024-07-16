namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] filledBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cupsQueue = new Queue<int>(cupsCapacity);
            Stack<int> bottlesStack = new Stack<int>(filledBottles);
            List<int> usedBottles = new List<int>();
            int sumOfWastedWater = 0;
            int countOfFullCups = 0;


            while (cupsQueue.Count > 0 && bottlesStack.Count > 0)
            {
                int cup = cupsQueue.Peek();
                int bottle = bottlesStack.Peek();

                if (cup - bottle > 0)
                {
                    while (cup > 0)
                    {
                        cup -= bottlesStack.Pop();
                    }
                    sumOfWastedWater += Math.Abs(cup);
                }
                else
                {
                    sumOfWastedWater += Math.Abs(cup -= bottle);
                    cup-= bottle;
                    bottlesStack.Pop();
                    countOfFullCups++;
                }

                if (cup <= 0)
                {
                    cupsQueue.Dequeue();
                }
            }

            if (cupsQueue.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottlesStack)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(' ', cupsQueue)}");
            }

            Console.WriteLine($"Wasted litters of water: {sumOfWastedWater}");
        }
    }
}
