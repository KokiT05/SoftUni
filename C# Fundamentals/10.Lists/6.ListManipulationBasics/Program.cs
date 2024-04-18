namespace _6.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToList();

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = input[0];

            while (command.ToLower() != "end") 
            {
                switch (command.ToLower())
                {
                    case "add":
                        numbers.Add(int.Parse(input[1]));
                        break;
                    case "remove":
                        numbers.Remove(int.Parse(input[1]));
                        break;
                    case "removeat":
                        numbers.RemoveAt(int.Parse(input[1]));
                        break;
                    case "insert":
                        numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                        break;
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                command = input[0];
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}