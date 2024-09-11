namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ");

            Func<char[], int, bool> func = (name, number) => name.Sum(c => c) >= number;
            Func<string[], Func<char[], int, bool>, string> findName = (names, func) =>
            names.FirstOrDefault(n => func(n.ToCharArray(), inputNumber));


            string name = findName(names, func);

            Console.WriteLine(name);
        }
    }
}
