namespace _08.ListOfPredicates_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] inputNumbers = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            List<int> range = new List<int>(inputNumbers.Length);

            for (int i = 1; i <= n; i++)
            {
                range.Add(i);
            }

            List<int> result = new List<int>(range);

            foreach (int number in inputNumbers)
            {
                Func<int, bool> numberFilter = numberFromRange => numberFromRange % number == 0;

                result = range.Where(numberFilter).ToList();
            }

            Console.WriteLine(string.Join(" ", result));

            //Code from the lecture
            //int end = int.Parse(Console.ReadLine());
            //List<int> dividers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            //List<int> numbers = Enumerable.Range(1, end).ToList();
            //Func<int, int, bool> predicate = (number, divisor) => number % divisor == 0;

            //foreach (int number in numbers)
            //{
            //    if (dividers.All(divisor => predicate(number, divisor)))
            //    {
            //        Console.Write(number + " ");
            //    }
            //}
        }
    }
}
