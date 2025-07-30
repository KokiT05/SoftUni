namespace Asynchronous_Programming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            Thread printNumbers = new Thread(() => PrintEvenNumbers(startNumber, endNumber));
            printNumbers.Start();
            printNumbers.Join();
            Console.WriteLine("Thread finished work");
        }

        public static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start + 1; i <= end; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
