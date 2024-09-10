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

            //Code from lecture
            //Dictionary<string, Func<int, int>> arithmeticFunctions =
            //new Dictionary<string, Func<int, int>>()
            //{
            //    {"add", number => number + 1 },
            //    {"multiply", number => number * 2 },
            //    {"subtract", number => number - 1 },
            //};

            //List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            //Action<List<int>> print = numbers => Console.WriteLine(string.Join(" ", numbers));

            //string command = Console.ReadLine();
            //while (command != "end")
            //{
            //    if (arithmeticFunctions.ContainsKey(command))
            //    {
            //        Func<int, int> func = arithmeticFunctions[command];
            //        numbers = numbers.Select(func).ToList();
            //    }
            //    else if (command == "print")
            //    {
            //        print(numbers);
            //    }

            //    command = Console.ReadLine();
            //}
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
