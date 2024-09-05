namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 100/100!!!
            int[] range = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            int lowRange = range[0];
            int highRange = range[1];

            List<int> numbers = new List<int>();

            for (int i = lowRange; i <= highRange; i++)
            {
                numbers.Add(i);
            }

            string typeOfNumbers = Console.ReadLine();

            Predicate<int> predicate = n => false;
            if (typeOfNumbers.ToLower() == "even")
            {
                predicate = n => n % 2 == 0;
            }
            else if (typeOfNumbers.ToLower() == "odd")
            {
                predicate = n => n % 2 != 0;
            }

            List<int> result = numbers.FindAll(predicate);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
