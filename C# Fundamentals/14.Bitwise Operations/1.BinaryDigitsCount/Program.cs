namespace _1.BinaryDigitsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int count = 0;
            while (number != 0)
            {
                int digit = number % 2;
                number = number / 2;

                if (digit == n)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}