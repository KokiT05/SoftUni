namespace _09.Sum_Of_OddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oddNumber = 1;
            int oddNumberSum = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                // i + i - 1
                Console.WriteLine(oddNumber);
                oddNumberSum += oddNumber;
                oddNumber += 2;
            }

            Console.WriteLine($"Sum: {oddNumberSum}");
        }
    }
}