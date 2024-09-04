using System.Threading.Channels;

namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            int[] result = numbers;

            Func<int, int> mathematicalOperations;

            string command = Console.ReadLine();
            while (command != "end")
            {
                mathematicalOperations = MathematicalOperations(command);
                result = result.Select(mathematicalOperations).ToArray();

                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", result));
                }

                command = Console.ReadLine();
            }
        }

        static Func<int, int> MathematicalOperations(string command)
        {
            switch (command)
            {
                case "add": return n => n + 1;
                case "multiply": return n => n * 2;
                case "subtract": return n => n - 1;
            }

            return n => n;
        }
    }
}
