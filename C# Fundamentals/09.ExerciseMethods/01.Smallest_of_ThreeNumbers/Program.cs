using System.Net.Http.Headers;

namespace _01.Smallest_of_ThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int result = MinNumber(firstNumber, secondNumber, thirdNumber);

            Console.WriteLine(result);


        }

        static int MinNumber(int firstNumber, int secondNumber, int thirdNumber) 
        {
            if (firstNumber <= secondNumber && firstNumber <= thirdNumber)
            {
                return firstNumber;
            }
            else if (secondNumber <= firstNumber && secondNumber <= thirdNumber)
            { 
                return secondNumber; 
            }
            else
            {
                return thirdNumber;
            }
        }
    }
}