namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, guest the number :)");
            Console.WriteLine("For exit enter 0");

            Console.Write("Enter your number [1, 10]: ");
            int inputNumber = int.Parse(Console.ReadLine());
            

            Random randomNumber = new Random();
            List<int> randomNumbers = new List<int>();
            int currentNumber = 0;

            while (inputNumber != 0)
            {
                currentNumber = randomNumber.Next(1, 11);
                if (inputNumber == currentNumber)
                {
                    Console.WriteLine("You win!");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect!");
                    Console.WriteLine($"Your number is: {inputNumber}");
                    Console.WriteLine($"The magic number was: {currentNumber}. Good luck next time :)");
                }

                Console.Write("Enter your number [1, 10]: ");
                inputNumber = int.Parse(Console.ReadLine());

                randomNumbers.Add(currentNumber);
            }
        }
    }
}