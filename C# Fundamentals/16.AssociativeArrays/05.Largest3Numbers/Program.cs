namespace _05.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int length = numbers.Length >= 3 ? 3 : numbers.Length;

            numbers = numbers.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}