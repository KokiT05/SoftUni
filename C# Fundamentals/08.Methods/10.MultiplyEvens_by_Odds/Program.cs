using System.Globalization;
using System.Runtime.CompilerServices;

namespace _10.MultiplyEvens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int sumOfEvenDigits = GetSumOfEvenDigits(number);
            int sumOfOddDogots = GetSumOfOddDigits(number);
            int result = GetMultipleOfEvenAndOdds(sumOfOddDogots, sumOfEvenDigits);
            Console.WriteLine(result);

        }

        static int GetSumOfEvenDigits(string numbers)
        {
            int sumOfEvenDigits = 0;
            for (int i = 0; i < numbers.Length; i++) 
            {
                string number = numbers[i].ToString();
                switch (number)
                {
                    case "2":
                        sumOfEvenDigits += 2;
                        break;
                    case "4":
                        sumOfEvenDigits += 4;
                        break;
                    case "6":
                        sumOfEvenDigits += 6;
                        break;
                    case "8":
                        sumOfEvenDigits += 8;
                        break;
                }
            }

            return sumOfEvenDigits;
        }

        static int GetSumOfOddDigits(string numbers) 
        {
            int sumOfOddDigits = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                string number = numbers[i].ToString();
                switch (number)
                {
                    case "1":
                        sumOfOddDigits += 1;
                        break;
                    case "3":
                        sumOfOddDigits += 3;
                        break;
                    case "5":
                        sumOfOddDigits += 5;
                        break;
                    case "7":
                        sumOfOddDigits += 7;
                        break;
                    case "9":
                        sumOfOddDigits += 9;
                        break;
                }
            }

            return sumOfOddDigits;
        }

        static int GetMultipleOfEvenAndOdds(int sumOfOddDigits, int sumOfEvenDigits)
        {
            int result = sumOfOddDigits * sumOfEvenDigits;

            return result;
        }
    }
}