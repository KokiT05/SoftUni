 namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            Func<int[], int> smallestNumber = sn =>
            {
                return sn.Min();
            };

            int smallestNumberFunc = smallestNumber(numbers);
            Console.WriteLine(smallestNumberFunc);
        }
    }
}
