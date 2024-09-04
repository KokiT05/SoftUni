namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            int number = int.Parse(Console.ReadLine());

            Predicate<int> predicate = n => n % number != 0;

            int[] result = Array.FindAll(numbers, predicate);

            Console.WriteLine(string.Join(" ", result.Reverse()));
        }
    }
}
