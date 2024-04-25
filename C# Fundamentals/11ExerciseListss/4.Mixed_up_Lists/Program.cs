namespace _4.Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToList();

            List<int> secondNumbers = Console.ReadLine()
                                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse)
                                             .ToList();

            int maxCount = Math.Max(firstNumbers.Count, secondNumbers.Count);
            int minCount = Math.Min(firstNumbers.Count, secondNumbers.Count);

            List<int> result = new List<int>(maxCount);
            for (int i = 0; i < minCount; i++)
            {
                result.Add(firstNumbers[i]);
                result.Add(secondNumbers[secondNumbers.Count - 1 - i]);
            }

            int initialBoundary = 0;
            int finalBoundary = 0;

            if (firstNumbers.Count >= secondNumbers.Count)
            {
                initialBoundary = firstNumbers[firstNumbers.Count - 2];
                finalBoundary = firstNumbers[firstNumbers.Count - 1];

                if (firstNumbers[firstNumbers.Count - 1] > firstNumbers[firstNumbers.Count - 2])
                {
                    initialBoundary = firstNumbers[firstNumbers.Count - 2];
                    finalBoundary = firstNumbers[firstNumbers.Count - 1];
                }
                else
                {
                    initialBoundary = firstNumbers[firstNumbers.Count - 1];
                    finalBoundary = firstNumbers[firstNumbers.Count - 2];
                }
            }
            else
            {
                initialBoundary = secondNumbers[0];
                finalBoundary = secondNumbers[1];

                if (secondNumbers[0] > secondNumbers[1])
                {
                    initialBoundary = secondNumbers[1];
                    finalBoundary = secondNumbers[0];
                }
                else
                {
                    initialBoundary = secondNumbers[0];
                    finalBoundary = secondNumbers[1];
                }
            }

            result.Sort();

            Console.WriteLine(string.Join(' ', result.Where(n => n > initialBoundary && n < finalBoundary)));
        }
    }
}