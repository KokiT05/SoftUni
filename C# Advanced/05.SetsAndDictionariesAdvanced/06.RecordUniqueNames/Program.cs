namespace _06.RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfName = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>(countOfName);

            for (int i = 0; i < countOfName; i++)
            {
                string name = Console.ReadLine();

                names.Add(name);
            }

            Console.WriteLine($"{string.Join(Environment.NewLine, names)}");
        }
    }
}
