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


            // Code from the lecture
            //Func<List<int>, int> minNumber = numbers =>
            //{
            //    int minNum = int.MaxValue;

            //    foreach (int num in numbers)
            //    {
            //        if (num < minNum)
            //        {
            //            minNum = num;
            //        }
            //    }

            //    return minNum;
            //};

            //List<int> numbers = Console.ReadLine()
            //                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //                .Select(int.Parse)
            //                .ToList();

            //int minNumberValue = minNumber(numbers);
            //Console.WriteLine(minNumberValue);
        }
    }
}
