namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double result = Factorial(firstNumber) / Factorial(secondNumber);
            Console.WriteLine($"{result:f2}");
        }

        static double Factorial(double number)
        {
            double result = 1.0;

            for (int i = (int)number; i > 0; i--)
            {
                result = result * i;
            }

            return result;
        }
    }
}