namespace _2.Gauss_Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numberList = Console.ReadLine()
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .Select(double.Parse)
                                            .ToList();

            CollectNumbers(numberList);

            Console.WriteLine(string.Join(' ', numberList));
        }

        static void CollectNumbers(List<double> numbers)
        {
            int count = numbers.Count / 2;

            for (int i = 0; i < count; i++)
            {
                numbers[i] = numbers[i] + numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
            }
        }
        
    }
}