namespace _5.RemoveNegativesAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                                    .Select(double.Parse)
                                    .Where(n => n > 0)
                                    .ToList();

            numbers.Reverse();

            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}