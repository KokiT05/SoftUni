namespace _01.Sign_of_IntegerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintSing(number);
        }

        static void PrintSing(int number)
        {
            string result = string.Empty;

            if (number > 0)
            {
                result = $"The number {number} is positive.";
            }
            else if (number < 0) 
            {
                result = $"The number {number} is negative.";
            }
            else
            {
                result = $"The number {number} is zero.";
            }

            Console.WriteLine(result);
        }
    }
}