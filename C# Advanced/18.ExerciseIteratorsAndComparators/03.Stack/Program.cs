namespace _03.Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new string[] { ", ", " "}, StringSplitOptions.RemoveEmptyEntries);
            string command = input[0];

            CustomStack<string> stack = new CustomStack<string>(input.Skip(1).ToArray());

            input = Console.ReadLine()
                .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries);
            while (command != "END" && input[0] != "END")
            {
                command = input[0];

                if (command == "Push")
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        stack.Push(input[i]);
                    }
                }
                else if (command == "Pop")
                {
                    try
                    {
                        Console.WriteLine(stack.Pop());
                    }
                    catch (InvalidOperationException invalidOperation)
                    {
                        Console.WriteLine(invalidOperation.Message);
                    }
                }

                input = Console.ReadLine()
                    .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
