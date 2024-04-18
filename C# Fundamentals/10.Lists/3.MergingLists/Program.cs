namespace _3.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> firstListNumber = new List<double>();
            firstListNumber = ReadList(firstListNumber);

            List<double> secondListNumber = new List<double>();
            secondListNumber = ReadList(secondListNumber);

            List<double> result = new List<double>(firstListNumber.Count + secondListNumber.Count);
            MergenList(firstListNumber, secondListNumber, result);

            Console.WriteLine(string.Join(' ', result));
        }

        static List<double> ReadList(List<double> numbers)
        {
            numbers = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(double.Parse)
                                    .ToList();

            return numbers;
        }

        static void MergenList(List<double> firstListNumber, 
                                List<double> secondListNumber, 
                                List<double> result) 
        {
            for (int i = 0; i < Math.Min(firstListNumber.Count, secondListNumber.Count); i++)
            {
                result.Add(firstListNumber[i]);
                result.Add(secondListNumber[i]);
            }

            if (firstListNumber.Count > secondListNumber.Count)
            {
                MergenLastNumbers(secondListNumber.Count, 
                                firstListNumber.Count, 
                                firstListNumber,
                                result);
            }
            else if (secondListNumber.Count > firstListNumber.Count)
            {
                MergenLastNumbers(firstListNumber.Count, 
                                    secondListNumber.Count, 
                                    secondListNumber,
                                    result);
            }
        }

        static void MergenLastNumbers(int startIndex, 
                                    int endIndex, 
                                    List<double> donor,
                                    List<double> list) 
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                list.Add(donor[i]);
            }
        }
    }
}