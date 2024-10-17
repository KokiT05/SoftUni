namespace _04.Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();
            Lake<string> lake = new Lake<string>(input);

            Console.WriteLine(string.Join(" ", lake));
        }
    }
}
