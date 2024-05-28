namespace _04.WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');

            Console.WriteLine(string.Join(Environment.NewLine, words.Where(w => w.Length % 2 == 0)));
        }
    }
}