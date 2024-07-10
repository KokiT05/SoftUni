namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> numbersQueue = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbersQueue.Enqueue(numbers[i]);
                }
            }

            while (numbersQueue.Count > 1)
            {
                Console.Write($"{numbersQueue.Dequeue()}, ");
            }

            Console.Write($"{numbersQueue.Dequeue()}");
        }
    }
}
