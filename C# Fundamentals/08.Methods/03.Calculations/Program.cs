namespace _03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            if (command == "add")
            {
                AddNumbers(firstNumber, secondNumber);
            }
            else if (command == "multiply")
            {
                MultiplyNumbers(firstNumber, secondNumber);
            }
            else if (command == "subtract")
            {
                SubtractNumbers(firstNumber, secondNumber);
            }
            else if (command == "divide")
            {
                DivideNumbers(firstNumber, secondNumber);
            }
        }

        static void AddNumbers(double firstNumber, double secondNumber)
        {
            double result = firstNumber + secondNumber;
            Console.WriteLine(result);
        }

        static void MultiplyNumbers(double firstNumber, double secondNumber)
        {
            double result = firstNumber * secondNumber;
            Console.WriteLine(result);
        }

        static void SubtractNumbers(double firstNumber, double secondNumber)
        {
            double result = firstNumber - secondNumber;
            Console.WriteLine(result);
        }

        static void DivideNumbers(double firstNumber, double secondNumber)
        {
            double result = Math.Round(firstNumber / secondNumber,2);
            Console.WriteLine(result);
        }
    }
}