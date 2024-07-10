namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            Queue<string> childrenQueue = new Queue<string>();
            foreach (string child in children)
            {
                childrenQueue.Enqueue(child);
            }

            int count = 0;
            while (childrenQueue.Count > 1)
            {
                count++;

                if (count == n)
                {
                    count = 0;
                    Console.WriteLine($"Removed {childrenQueue.Dequeue()}");
                }
                else
                {
                    childrenQueue.Enqueue(childrenQueue.Dequeue());
                }
            }

            Console.WriteLine($"Last is {childrenQueue.Dequeue()}");
        }
    }
}
