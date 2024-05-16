namespace _2.BitAtPosition1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int position = 1;

            number = (number >> position);
            Console.WriteLine(number % 2);
        }
    }
}