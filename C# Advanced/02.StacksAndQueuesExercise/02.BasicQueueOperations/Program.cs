namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] operationNumber = Console.ReadLine().Split().Select(n => int.Parse(n)).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(n => int.Parse(n)).ToArray();

            Queue<int> numbersQueue = new Queue<int>();

            int numberOfEnqueue = operationNumber[0];
            int numberOfDequeue = operationNumber[1];
            int keyNumber = operationNumber[2];

            for (int i = 0; i < numberOfEnqueue; i++)
            {
                numbersQueue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numberOfDequeue; i++)
            {
                numbersQueue.Dequeue();
            }

            if (numbersQueue.Any() == false)
            {
                Console.WriteLine(0);
            }
            else if (numbersQueue.Contains(keyNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbersQueue.Min());
            }
        }
    }
}
