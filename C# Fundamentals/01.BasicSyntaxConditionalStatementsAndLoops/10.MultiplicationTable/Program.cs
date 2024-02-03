namespace _10.MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int result = 0;

            for (int i = 1; i <= 10; i++)
            {
                result = n * i;
                Console.WriteLine($"{n} X {i} = {result}");
            }
        }
    }
}