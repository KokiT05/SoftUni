namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] operationNumber = Console.ReadLine().Split().Select(n => int.Parse(n)).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(n => int.Parse(n)).ToArray();

            Stack<int> numbersStack = new Stack<int>();

            int numberOfPush = operationNumber[0];
            int numberOfPop = operationNumber[1];
            int keyNumber = operationNumber[2];

            for (int i = 0; i < numberOfPush; i++)
            {
                numbersStack.Push(numbers[i]);
            }

            for (int i = 0; i < numberOfPop; i++)
            {
                numbersStack.Pop();
            }

            if (numbersStack.Any() == false)
            {
                Console.WriteLine(0);
            }
            else if (numbersStack.Contains(keyNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                //Console.WriteLine(numbersStack.Min());

                int minElement = numbersStack.Pop();

                foreach (int number in numbersStack)
                {
                    if (number < minElement)
                    {
                        minElement = number;
                    }
                }
                Console.WriteLine(minElement);

            }
        }
    }
}
