namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> filterNameLength = name => name.Length <= length;

            string[] filteredName = names.Where(filterNameLength).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, filteredName));

            //Predicate<string> predicate = n => n.Length <= length;

            //string[] filteredNames = Array.FindAll(names, predicate);

            //Console.WriteLine(string.Join(Environment.NewLine, filteredNames));
        }
    }
}
