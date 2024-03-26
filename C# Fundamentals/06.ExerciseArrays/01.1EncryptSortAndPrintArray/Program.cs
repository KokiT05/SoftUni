using System;
using System.Linq;

namespace _01._1EncryptSortAndPrintArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] sequenceOfString = new string[length];

            string input = string.Empty;
            for (int i = 0; i < sequenceOfString.Length; i++)
            {
                input = Console.ReadLine();
                sequenceOfString[i] = input;
            }

            int[] encryptArray = new int[length];
            int sumOfVowel = 0;
            int sumOfConsonant = 0;
            int result = 0;
            int index = 0;
            foreach (string str in sequenceOfString)
            {
                sumOfVowel = 0;
                sumOfConsonant = 0;
                result = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    char letter = str[i];
                    switch (str[i])
                    {
                        case 'A':
                        case 'E':
                        case 'I':
                        case 'O':
                        case 'U':
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                            sumOfVowel += letter * str.Length;
                            break;
                        case 'B':
                        case 'C':
                        case 'D':
                        case 'F':
                        case 'G':
                        case 'H':
                        case 'J':
                        case 'K':
                        case 'L':
                        case 'M':
                        case 'N':
                        case 'P':
                        case 'Q':
                        case 'R':
                        case 'S':
                        case 'T':
                        case 'V':
                        case 'W':
                        case 'X':
                        case 'Y':
                        case 'Z':
                        case 'b':
                        case 'c':
                        case 'd':
                        case 'f':
                        case 'g':
                        case 'h':
                        case 'j':
                        case 'k':
                        case 'l':
                        case 'm':
                        case 'n':
                        case 'p':
                        case 'q':
                        case 'r':
                        case 's':
                        case 't':
                        case 'v':
                        case 'w':
                        case 'x':
                        case 'y':
                        case 'z':
                            sumOfConsonant += letter / str.Length;
                            break;
                    }
                }
                result = sumOfVowel + sumOfConsonant;
                encryptArray[index] = result;
                index++;
            }

            Array.Sort(encryptArray);

            Console.WriteLine(string.Join(Environment.NewLine, encryptArray));
        }
    }
}
