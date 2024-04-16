using System;
using System.Text;
using System.Linq;

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] inputNumbers = Console
                                .ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            string arrayManipulationCommands = string.Empty;
            while ((arrayManipulationCommands = Console.ReadLine().ToLower()) != "end")
            {
                string[] inputCommands = arrayManipulationCommands
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = inputCommands[0];
                command = command.ToLower();
                bool isValidIndex;
                if (command == "exchange")
                {
                    int index = int.Parse(inputCommands[1]);

                    if (index < 0 || index > inputNumbers.Length - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    Exchange(index, inputNumbers);
                }
                else if (command == "max")
                {
                    if (inputCommands[1] == "even")
                    {
                        if (MaxEvenNumberIndex(inputNumbers) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MaxEvenNumberIndex(inputNumbers));
                    }
                    else if (inputCommands[1] == "odd")
                    {
                        if (MaxOddNumberIndex(inputNumbers) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MaxOddNumberIndex(inputNumbers));
                    }
                }
                else if (command == "min")
                {
                    if (inputCommands[1] == "even")
                    {
                        if (MinEvenNumber(inputNumbers) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MinEvenNumber(inputNumbers));
                    }
                    else if (inputCommands[1] == "odd")
                    {
                        if (MinOddNumber(inputNumbers) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MinOddNumber(inputNumbers));
                    }
                }
                else if (command == "first")
                {
                    int count = int.Parse(inputCommands[1]);

                    if (inputCommands[2] == "even")
                    {
                        FirstEvenNumbers(count, inputNumbers);
                    }
                    else if (inputCommands[2] == "odd")
                    {
                        FirstOddNumbers(count, inputNumbers);
                    }
                }
                else if (command == "last")
                {
                    int count = int.Parse(inputCommands[1]);

                    bool isCountValid = IsCountValid(count, inputNumbers);
                    if (!isCountValid)
                    {
                        continue;
                    }

                    string typeOfOperation = inputCommands[2];
                    string result = string.Empty;
                    if (typeOfOperation == "even")
                    {
                        result = LastEvenNumbers(count, inputNumbers);
                    }
                    else if (typeOfOperation == "odd")
                    {
                        result = LastOddNumbers(count, inputNumbers);
                    }

                    Console.WriteLine($"[{result}]");
                }
            }

            Console.WriteLine($"[{string.Join(", ", inputNumbers)}]");
        }

        static bool IsValidIndex(int index, int[] array)
        {
            if (index < 0 || index >= array.Length)
            {
                Console.WriteLine("Invalid index");
                return false;
            }

            return true;
        } // YES
        static void Exchange(int index, int[] numberArray)
        {
            int[] firstArray = new int[numberArray.Length - index - 1];
            int[] secondArray = new int [index + 1];

            int firstArrayIndex = 0;
            for (int i = index + 1; i < numberArray.Length; i++)
            {
                firstArray[firstArrayIndex] = numberArray[i];
                firstArrayIndex++;
            }

            for (int i = 0; i < index + 1; i++)
            {
                secondArray[i] = numberArray[i];
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                numberArray[i] = firstArray[i];
            }

            for (int i = 0; i < secondArray.Length; i++)
            {
                numberArray[firstArray.Length + i] = secondArray[i];
            }
        } // YES
        static bool IsEvenNumberFound(int[] numbers)
        {
            bool isEvenNumberFound = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    isEvenNumberFound = true;
                    return isEvenNumberFound;
                }
            }

            return isEvenNumberFound;
        } // YES
        static int MaxEvenNumberIndex(int[] numbers)
        {
            int maxEven = int.MinValue;
            int index = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    if (numbers[i] >= maxEven)
                    {
                        maxEven = numbers[i];
                        index = i;
                    }
                }
            }

            return index;
        } // YES
        static int MinEvenNumber(int[] numbers)
        {
            int minEven = int.MaxValue;
            int index = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    if (numbers[i] <= minEven)
                    {
                        minEven = numbers[i];
                        index = i;
                    }
                }
            }

            return index;
        }  // YES

        static bool IsOddNumberFound(int[] numbers)
        {
            bool isOddNumberFound = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    isOddNumberFound = true;
                    return isOddNumberFound;
                }
            }

            return isOddNumberFound;
        } // YES
        static int MaxOddNumberIndex(int[] numbers)
        {
            int maxOdd = int.MinValue;
            int index = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    if (numbers[i] >= maxOdd)
                    {
                        maxOdd = numbers[i];
                        index = i;
                    }
                }
            }

            return index;
        } // YES
        static int MinOddNumber(int[] numbers)
        {
            int minOdd = int.MaxValue;
            int index = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    if (numbers[i] <= minOdd)
                    {
                        minOdd = numbers[i];
                        index = i;
                    }
                }
            }

            return index;
        } // YES

        static bool IsCountValid(int index, int[] numbers)
        {
            if (index <= 0 || index > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return false;
            }

            return true;
        } // YES
        static void FirstOddNumbers(int count ,int[] numbers)
        {
            string numbersStr = string.Empty;
            int counter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    numbersStr += numbers[i] + " ";
                    counter++;
                }

                if (counter == count)
                {
                    break;
                }
            }

            var result = numbersStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + String.Join(", ", result) + "]");
            }
        } // YES

        static void FirstEvenNumbers(int count, int[] numbers)
        {
            string numbersStr = string.Empty;
            int counter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbersStr += numbers[i] + " ";
                    counter++;
                }

                if (counter == count)
                {
                    break;
                }
            }

            var result = numbersStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + String.Join(", ", result)+ "]");
            }
        }

        static string LastEvenNumbers(int index, int[] numbers)
        {

            string stringBuilder = "";

            bool isEvenNumberFoud = IsEvenNumberFound(numbers);

            if (isEvenNumberFoud)
            {
                int currentIndex = 0;
                for (int i = numbers.Length - 1; i >= 0; i--)
                {

                    if (numbers[i] % 2 == 0)
                    {
                        stringBuilder += numbers[i] + " ";
                        currentIndex++;
                    }

                    if (currentIndex == index)
                    {
                        break;
                    }
                }

                stringBuilder = string.Join(", ", stringBuilder.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToString();
            }


            return stringBuilder;
        } // YES

        static string LastOddNumbers(int index, int[] numbers)
        {
            string stringBuilder = "";

            bool isOddNumberFoud = IsOddNumberFound(numbers);

            if (isOddNumberFoud)
            {
                int currentIndex = 0;
                for (int i = numbers.Length - 1; i >= 0; i--)
                {

                    if (numbers[i] % 2 != 0)
                    {
                        stringBuilder += numbers[i] + " ";
                        currentIndex++;
                    }

                    if (currentIndex == index)
                    {
                        break;
                    }
                }


                stringBuilder = string.Join(", ", stringBuilder.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToString();
            }


            return stringBuilder;
        }
    }
}