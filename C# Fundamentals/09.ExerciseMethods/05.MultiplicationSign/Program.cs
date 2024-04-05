using Microsoft.VisualBasic;

namespace _05.MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNUmber = double.Parse(Console.ReadLine());
            double thirdNumber = double.Parse(Console.ReadLine());

            Sing(firstNumber, secondNUmber, thirdNumber);

        }

        static void Sing(double firstNUmber, double secondNUmber, double thirdNumber)
        {
            bool isNegative = IsNegative(firstNUmber, secondNUmber, thirdNumber);

            if (firstNUmber == 0 || secondNUmber == 0 || thirdNumber == 0)
            {
                Console.WriteLine("zero");
            }
            else if (isNegative)
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }

            //if (firstNUmber < 0 || secondNUmber < 0 || thirdNumber < 0)
            //{

            //    Console.WriteLine("negative");
            //    return;
            //}
            //else if (firstNUmber == 0 || secondNUmber == 0 || thirdNumber == 0)
            //{
            //    Console.WriteLine("zero");
            //    return;
            //}
            //else
            //{
            //    Console.WriteLine("positive");
            //    return;
            //}
        }

        static bool IsNegative(double firstNumber, double secondNumber, double thirdNumber)
        {
            if (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0)
            {
                return false;
            }
            else if (firstNumber < 0 && secondNumber < 0 && thirdNumber > 0)
            {
                return false;
            }
            else if (firstNumber > 0 && secondNumber < 0 && thirdNumber < 0)
            {
                return false;
            }
            else if (firstNumber < 0 && secondNumber > 0 && thirdNumber < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}