namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setsSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstSetSize = setsSize[0];
            int secondSetSize = setsSize[1];

            HashSet<int> firstSets = new HashSet<int>(firstSetSize);
            HashSet<int> secondSets = new HashSet<int>(secondSetSize);

            int number = 0;
            for (int i = 0; i < firstSetSize; i++)
            {
               number = int.Parse(Console.ReadLine());
                firstSets.Add(number);
            }

            for (int i = 0; i < secondSetSize; i++)
            {
                number = int.Parse(Console.ReadLine());
                secondSets.Add(number);
            }

            firstSets = firstSets.Intersect(secondSets).ToHashSet();

            Console.WriteLine(string.Join(' ', firstSets));
        }
    }
}
