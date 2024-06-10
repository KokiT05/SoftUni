namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            string newNumber = string.Empty;
            int indexOfNewNumber = 0;

            int currentNumber = 0;
            for (int i = firstNumber.Length - 1; i >= 0 ; i++)
            {
                currentNumber = int.Parse(firstNumber[i].ToString());
                currentNumber = currentNumber * secondNumber;

                while (currentNumber != 0)
                {

                }
            }


        }
    }
}