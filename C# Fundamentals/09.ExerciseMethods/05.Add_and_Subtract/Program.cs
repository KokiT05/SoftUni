namespace _05.Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double thirdNumber = double.Parse(Console.ReadLine());

            double sumResult = Sum(firstNumber, secondNumber);
            double subtractResult = Subtract(sumResult, thirdNumber);
            Console.WriteLine(subtractResult);
        }

        static double Sum(double firstNumber, double secondNUmber)
        {
            double result = 0.0;

            result = firstNumber + secondNUmber;

            return result;

        }

        static double Subtract(double firstNumber, double secondNUmber)
        {
            double result = 0.0;

            result = firstNumber - secondNUmber;

            return result;
        }
    }
}