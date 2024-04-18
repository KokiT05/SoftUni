namespace CalculatorProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to the calculator");

            while (true) 
            {
                float firstNumber = FirstNumber();

                float secondNumber = SecondNumber();

                char mathOperation = MathOperation();

                Calculation(firstNumber, mathOperation, secondNumber);
            }
        }

        static void Calculation(float firstNumber, char mathOperation, float secondNumber)
        {
            float result = 0.0F;
            if (mathOperation == '+')
            {
                result = firstNumber + secondNumber;
            }
            else if (mathOperation == '-')
            {
                result = firstNumber - secondNumber;
            }
            else if (mathOperation == '*')
            {
                result = firstNumber * secondNumber;
            }
            else if (mathOperation == '/' && secondNumber != 0)
            {
                result = firstNumber / secondNumber;
            }
            else
            {
                Console.WriteLine("Invalid operation!");
                return;
            }

            Console.WriteLine($"The result is: {firstNumber} {mathOperation} {secondNumber} = {result:f2}");
        }

        static float FirstNumber()
        {
            Console.Write("Enter your first number: ");
            float firstNumber = CheckNumber(Console.ReadLine());
            return firstNumber;
        }

        static float SecondNumber() 
        {
            Console.Write("Enter your second number: ");
            float secondNumber = CheckNumber(Console.ReadLine());
            return secondNumber;
        }

        static float CheckNumber(string number)
        {
            float currentNumber = 0.0F;
            bool isNumber = float.TryParse(number, out currentNumber);
            while (isNumber == false)
            {
                Console.WriteLine("Invalid number!");
                Console.Write("Enter number: ");
                number = Console.ReadLine();
                isNumber = float.TryParse(number, out currentNumber);
            }

            return currentNumber;
        }

        static char MathOperation()
        {
            Console.Write("Choose an operation: (+)|(-)|(*)|(/)| ");
            char mathOperation = CheckOperation(Console.ReadLine());
            return mathOperation;
        }

        static char CheckOperation(string operation) 
        {
            bool isValidOperation = operation == "+"
                                || operation == "-"
                                || operation == "*"
                                || operation == "/";

            while (!isValidOperation)
            {
                Console.WriteLine("Invalid operation!");
                Console.Write("Choose an operation: (+)|(-)|(*)|(/)| ");
                operation = Console.ReadLine();
                isValidOperation = operation == "+"
                                || operation == "-"
                                || operation == "*"
                                || operation == "/";
            }

            return operation[0];
        }



    }
}