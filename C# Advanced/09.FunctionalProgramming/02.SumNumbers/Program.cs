namespace _02.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> count = n => Console.WriteLine(n.Length);
            Action<int[]> sum = n =>
            {
                int sum = 0;
                foreach (int number in n)
                {
                    sum += number;
                }

                Console.WriteLine(sum);
            };
            Func<string, int> parser = n => int.Parse(n);
            int[] numbers = Console.ReadLine().Split(", ").Select(parser).ToArray();

            PrintInformation(sum, count,numbers);
        }

        static void PrintInformation(Action<int[]> sum, Action<int[]> count, int[] numbers)
        {
            count(numbers);
            sum(numbers);
        }
    }
}
