using System.Text;

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
                else if (operationCommand == "max")
                {
                    index = -1;

                    string evenOrOdd = commands[1].ToLower();
                    switch (evenOrOdd)
                    {
                        case "even":
                            index = MaxEvenNumber(numbers);
                            break;
                        case "odd":
                            index = MaxOddNumber(numbers);
                            break;
                    }

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }
                else if (operationCommand == "min")
                {
                    index = -1;

                    string evenOrOdd = commands[1].ToLower();
                    switch (evenOrOdd)
                    {
                        case "even":
                            index = MinEvenNumber(numbers);
                            break;
                        case "odd":
                            index = MinOddNumber(numbers);
                            break;
                    }

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }
                else if (operationCommand == "first")
                {
                    if (int.Parse(commands[1]) < 0 || int.Parse(commands[1]) > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        string result = "";
                        switch (commands[2])
                        {
                            case "odd":
                                result = FirstOddNumbers(int.Parse(commands[1]), numbers);
                                break;
                            case "even":
                                result = FirstEvenNumbers(int.Parse(commands[1]), numbers);
                                break;
                        }
                        Console.WriteLine($"[{result}]");
                    }


                    //Console.WriteLine($"[{result}]");
                }
                else if (operationCommand == "last")
                {
                    if (int.Parse(commands[1]) < 0 || int.Parse(commands[1]) > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        string result = "";
                        switch (commands[2])
                        {
                            case "odd":
                                result = LastOddNumbers(int.Parse(commands[1]), numbers);
                                break;
                            case "even":
                                result = LastEvenNumbers(int.Parse(commands[1]), numbers);
                                break;
                        }
                        Console.WriteLine($"[{result}]");
                    }
                }
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
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
            for (int i = index + 1; i < numberArray.Length; i++)
            {
                newNumberArray[newNumberArrayIndex] = numberArray[i];
                newNumberArrayIndex++;
            }

            for (int i = 0; i < index + 1; i++)
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
            int maxEvenNUmber = 0;
            int maxEvenIdex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    if (numbers[i] >= maxEvenNUmber)
                    {
                        maxEvenNUmber = numbers[i];
                        maxEvenIdex = i;
                    }
                }
            }

            return maxEvenIdex;
        }

        static int MinEvenNumber(int[] numbers)
        {
            int minEvenNUmber = numbers[0];
            int minEvenIdex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    if (numbers[i] <= minEvenNUmber)
                    {
                        minEvenNUmber = numbers[i];
                        minEvenIdex = i;
                    }
                }
            }

            return minEvenIdex;
        }

        static int MaxOddNumber(int[] numbers)
        {
            int maxOddNumber = 0;
            int maxOddIdex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    if (numbers[i] >= maxOddNumber)
                    {
                        maxOddNumber = numbers[i];
                        maxOddIdex = i;
                    }
                }
            }

            return maxOddIdex;
        }

        static int MinOddNumber(int[] numbers)
        {
            int minOddNumber = numbers[0];
            int minOddIdex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    if (numbers[i] <= minOddNumber)
                    {
                        minOddNumber = numbers[i];
                        minOddIdex = i;
                    }
                }
            }

            return minOddIdex;
        }

        static string FirstOddNumbers(int index, int[] numbers)
        {
            string stringBuilder = "";

            int currentIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                switch (numbers[i])
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 9:
                        stringBuilder += numbers[i] + " ";
                        currentIndex++;
                        break;
                    default:
                        break;
                }

                if (currentIndex == index)
                {
                    break;
                }
            }

            stringBuilder = string.Join(", ", stringBuilder.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToString();

            return stringBuilder;
        }

        static string FirstEvenNumbers(int index, int[] numbers)
        {
            string stringBuilder = "";

            int currentIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                switch (numbers[i])
                {
                    case 2:
                    case 4:
                    case 6:
                    case 8:
                        stringBuilder += numbers[i] + " ";
                        currentIndex++;
                        break;
                    default:
                        break;
                }

                if (currentIndex == index)
                {
                    break;
                }
            }

            stringBuilder = string.Join(", ", stringBuilder.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToString();

            return stringBuilder;
        }

        static string LastEvenNumbers(int index, int[] numbers)
        {
            string stringBuilder = "";

            int currentIndex = 0;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                switch (numbers[i])
                {
                    case 2:
                    case 4:
                    case 6:
                    case 8:
                        stringBuilder += numbers[i] + " ";
                        currentIndex++;
                        break;
                    default:
                        break;
                }

                if (currentIndex == index)
                {
                    break;
                }
            }

            stringBuilder = string.Join(", ", stringBuilder.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToString();

            return stringBuilder;
        }

        static string LastOddNumbers(int index, int[] numbers)
        {
            string stringBuilder = "";

            int currentIndex = 0;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                switch (numbers[i])
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 9:
                        stringBuilder += numbers[i] + " ";
                        currentIndex++;
                        break;
                    default:
                        break;
                }

                if (currentIndex == index)
                {
                    break;
                }
            }

            stringBuilder = string.Join(", ", stringBuilder.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToString();

            return stringBuilder;
        }
    }
}