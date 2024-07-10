namespace _06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> namesQueue = new Queue<string>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                namesQueue.Enqueue(input);

                if (input == "Paid")
                {
                    while (namesQueue.Count > 1)
                    {
                        Console.WriteLine(namesQueue.Dequeue());
                    }
                    namesQueue.Dequeue();
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{namesQueue.Count} people remaining.");
        }
    }
}
