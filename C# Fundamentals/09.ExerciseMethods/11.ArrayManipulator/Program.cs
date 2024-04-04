namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console
                            .ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] commands = input
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => x.ToLower())
                                    .ToArray();

                string operationCommand = commands[0].ToLower();
                int index = 0;

                if (operationCommand == "exchange")
                {
                    index = int.Parse(commands[1]);
                    Exchange(index, numbers);
                }
                else if (operationCommand == "max" && commands[1] == "even")
                {
                    int maxEven = MaxEvenNumber(numbers);
                    Console.WriteLine(maxEven);
                }

                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static void Exchange(int index, int[] numberArray)
        {
            int[] newNumberArray = new int[numberArray.Length];

            if (index < 0 || index >= numberArray.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            int newNumberArrayIndex = 0;
            for (int i = index; i < numberArray.Length; i++)
            {
                newNumberArray[newNumberArrayIndex] = numberArray[i];
                newNumberArrayIndex++;
            }

            for (int i = 0; i < index; i++)
            {
                newNumberArray[newNumberArrayIndex] = numberArray[i];
                newNumberArrayIndex++;
            }

            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = newNumberArray[i];
            }
        }

        static int MaxEvenNumber(int[] numbers)
        {
            int maxEvenNUmber = 2;
            int maxEvenIdex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                switch (numbers[i])
                {
                    case 2:
                    case 4:
                    case 6:
                    case 8:
                            if (numbers[i] > maxEvenNUmber)
                            {
                                maxEvenNUmber = numbers[i];
                                maxEvenIdex = i;
                            }
                        break;
                    default:
                        break;
                }
            }

            return maxEvenIdex;
        }
    }
}