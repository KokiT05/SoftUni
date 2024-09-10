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

            Predicate<string> predicate = n => n.Length <= length;

            string[] filteredNames = Array.FindAll(names, predicate);

            Console.WriteLine(string.Join(Environment.NewLine, filteredNames));

            //Code from lecture
            //int n = int.Parse(Console.ReadLine());
            //List<string> names = Console.ReadLine().Split(" ").ToList();

            //Func<string, int, bool> func = (name, length) => name.Length <= length;

            //names = names.Where(name => func(name, n)).ToList();

            //Action<List<string>> print = 
            //    names => Console.WriteLine(string.Join(Environment.NewLine, names));
            //print(names);
        }
    }
}
