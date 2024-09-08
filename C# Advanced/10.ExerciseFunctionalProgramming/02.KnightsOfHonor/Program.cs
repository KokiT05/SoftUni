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

            // Code from the lecture
            //List<string> names = Console.ReadLine().Split(" ").ToList();
            //List<string> newNames = names.Select(name => $"Sir {name}").ToList();
            //Action<List<string>> printName =
            //n => Console.WriteLine(string.Join(Environment.NewLine, n));

            //printName(newNames);
        }
    }
}
