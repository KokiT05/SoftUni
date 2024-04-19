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

            bool isChange = false;
            while (command.ToLower() != "end")
            {
                switch (command.ToLower())
                {
                    case "add":
                        numbers.Add(int.Parse(input[1]));
                        isChange = true;
                        break;
                    case "remove":
                        numbers.Remove(int.Parse(input[1]));
                        isChange = true;
                        break;
                    case "removeat":
                        numbers.RemoveAt(int.Parse(input[1]));
                        isChange = true;
                        break;
                    case "insert":
                        numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                        isChange = true;
                        break;
                    case "contains":
                        Console.WriteLine(numbers.Contains(int.Parse(input[1])) ? "Yes" : "No such number");
                        break;
                    case "printeven":
                        Console.WriteLine(string.Join(' ', numbers.Where(n => n % 2 == 0)));
                        break;
                    case "printodd":
                        Console.WriteLine(string.Join(' ', numbers.Where(n => n % 2 != 0)));
                        break;
                    case "getsum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "filter":
                        int number = int.Parse(input[2]);
                        if (input[1] == "<")
                        {
                            Console.WriteLine(string.Join(' ', numbers.Where(n => n < number)));
                        }
                        else if (input[1] == ">")
                        {
                            Console.WriteLine(string.Join(' ', numbers.Where(n => n > number)));
                        }
                        else if (input[1] == ">=")
                        {
                            Console.WriteLine(string.Join(' ', numbers.Where(n => n >= number)));
                        }
                        else if (input[1] == "<=")
                        {
                            Console.WriteLine(string.Join(' ', numbers.Where(n => n <= number)));
                        }
                        break;
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                command = input[0];
            }

            if (isChange)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}