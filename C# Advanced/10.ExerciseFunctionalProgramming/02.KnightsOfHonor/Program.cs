namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> result = r =>
            {
                 foreach (string name in names)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };

            result(names);
        }
    }
}
