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

            //Code from lecture
            //List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            //int n = int.Parse(Console.ReadLine());
            //numbers.Reverse();

            //Predicate<int> predicate = number => number % n != 0;
            //numbers = MyWhere(numbers, predicate);

            //Action<List<int>> print = numbers => Console.WriteLine(string.Join(" ", numbers));
            //print(numbers);  
        }

        //static List<int> MyWhere(List<int> numbers, Predicate<int> predicate)
        //{
        //    List<int> newNumbers = new List<int>();

        //    foreach (int currentNumber in numbers)
        //    {
        //        if (predicate(currentNumber))
        //        {
        //            newNumbers.Add(currentNumber);
        //        }
        //    }

        //    return newNumbers;
        //}
    }
}
