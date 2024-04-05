using System;
using System.Text;

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
                    isValidIndex = IsValidIndex(index, inputNumbers);

                    if (!isValidIndex)
                    {
                        continue;
                    }

                    Exchange(index, inputNumbers);
                }
                else if (command == "max")
                {
                    string typeOfNumber = inputCommands[1];
                    if (typeOfNumber == "even")
                    {
                        MaxEvenNumberIndex(inputNumbers);
                    }
                    else if (typeOfNumber == "odd")
                    {
                        MaxOddNumber(inputNumbers);
                    }
                }
                else if (command == "min")
                {
                    string typeOfNumber = inputCommands[1];
                    if (typeOfNumber == "even")
                    {
                        MinEvenNumber(inputNumbers);
                    }
                    else if (typeOfNumber == "odd")
                    {
                        MinOddNumber(inputNumbers);
                    }
                }
                else if (command == "first")
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
                        result = FirstEvenNumbers(count, inputNumbers);
                    }
                    else if (typeOfOperation == "odd")
                    {
                        result = FirstOddNumbers(count, inputNumbers);
                    }

                    Console.WriteLine($"[{result}]");
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
            int[] newNumberArray = new int[numberArray.Length];

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
        static void MaxEvenNumberIndex(int[] numbers)
        {
            bool isEvenNumberFound = IsEvenNumberFound(numbers);

            if (isEvenNumberFound)
            {
                int maxEvenNUmber = numbers[0];
                int maxEvenIdex = 0;

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

                Console.WriteLine(maxEvenIdex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        } // YES
        static void MinEvenNumber(int[] numbers)
        {
            bool isEvenNumberFound = IsEvenNumberFound(numbers);
            if (isEvenNumberFound)
            {
                int minEvenNUmber = numbers[0];
                int minEvenIdex = 0;

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

                Console.WriteLine(minEvenIdex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
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
        static void MaxOddNumber(int[] numbers)
        {
            bool isOddNumberFound = IsOddNumberFound(numbers);
            if (isOddNumberFound)
            {
                int maxOddNumber = numbers[0];
                int maxOddIdex = 0;

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

                Console.WriteLine(maxOddIdex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        } // YES
        static void MinOddNumber(int[] numbers)
        {
            bool isOddNumberFound = IsOddNumberFound(numbers);

            if (isOddNumberFound)
            {
                int minOddNumber = numbers[0];
                int minOddIdex = 0;

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

                Console.WriteLine(minOddIdex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
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
        static string FirstOddNumbers(int index ,int[] numbers)
        {
            string stringBuilder = "";

            bool isOddNumberFound = IsOddNumberFound(numbers);
            if (isOddNumberFound)
            {
                int currentIndex = 0;
                for (int i = 0; i < numbers.Length; i++)
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

                stringBuilder = string.Join(", ", stringBuilder
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToString();
            }

            return stringBuilder;
        } // YES

        static string FirstEvenNumbers(int index, int[] numbers)
        {
            string stringBuilder = "";

            bool isEvenNumberFoud = IsEvenNumberFound(numbers);
            if (isEvenNumberFoud)
            {
                int currentIndex = 0;
                for (int i = 0; i < numbers.Length; i++)
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

                stringBuilder = string.Join(", ", stringBuilder
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToString();
            }

            return stringBuilder;
        } // !!!

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