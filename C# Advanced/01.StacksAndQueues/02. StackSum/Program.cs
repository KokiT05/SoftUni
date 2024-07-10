namespace _02._StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbersInStack = new Stack<int>();
            foreach (int number in numbers)
            {
                numbersInStack.Push(number);
            }

            string inputData = Console.ReadLine().ToLower();
            while (inputData != "end")
            {
                string[] commandArg = inputData.Split();
                string command = commandArg[0];

                if (command == "add")
                {
                    AddNumbers(numbersInStack, commandArg);
                }
                else if (command == "remove")
                {
                    int count = int.Parse(commandArg[1]);
                    RemoveNumbers(numbersInStack, count);
                }

                inputData = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {numbersInStack.Sum()}");

        }

        static void AddNumbers(Stack<int> numbers, string[] inputData) 
        {
            int firstNumber = int.Parse(inputData[1]);
            int secondNumber = int.Parse(inputData[2]);

            numbers.Push(firstNumber);
            numbers.Push(secondNumber);
        }

        static void RemoveNumbers(Stack<int> numbers, int count)
        {

            if (count <= numbers.Count)
            {
                for (int i = 1; i <= count; i++)
                {
                    numbers.Pop();
                }
            }
        }
    }
}
