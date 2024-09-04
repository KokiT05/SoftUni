namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> result = r => 
            { 
                Console.WriteLine(string.Join(Environment.NewLine, r)); 
            };

            result(input);
        }
    }
}
