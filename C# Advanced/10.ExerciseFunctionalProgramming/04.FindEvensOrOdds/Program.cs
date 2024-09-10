namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //100 / 100!!!
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

            //Code from the lecture
            //int[] range = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            //int start = range[0];
            //int end = range[1];
            //string criteria = Console.ReadLine();

            //Func<int, int, List<int>> generateRangeOfNumbers = (s, e) =>
            //{
            //    List<int> numbers = new List<int>();

            //    for (int i = s; i <= e; i++)
            //    {
            //        numbers.Add(i);
            //    }

            //    return numbers;
            //};
            //List<int> numbers = generateRangeOfNumbers(start, end);

            //Predicate<int> predicate = n => true;

            //if (criteria == "odd")
            //{
            //    predicate = n => n % 2 != 0;
            //}
            //else if (criteria == "even")
            //{
            //    predicate = n => n % 2 == 0;
            //}

            //Console.WriteLine(string.Join(" ", MyWhere(numbers, predicate)));
        }

        static List<int> MyWhere(List<int> numbers, Predicate<int> predicate)
        {
            List<int> newNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (predicate(number))
                {
                    newNumbers.Add(number);
                }
            }

            return newNumbers;
        }
    }
}
