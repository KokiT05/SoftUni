using System.Linq;

namespace _01.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = Console.ReadLine()
            //                        .Split(", ")
            //                        .Select(n => int.Parse(n))
            //                        .ToArray();

            //Console.WriteLine(string.Join(", ", numbers
            //                    .Where(n => n % 2 == 0)
            //                    .OrderBy(n => n)));

            Console.WriteLine
                    (string.Join(", ", 
                        Console.ReadLine()
                        .Split(", ")
                        .Select(n => int.Parse(n))
                        .Where(n => n % 2 == 0)
                        .OrderBy(n => n)));
        }
    }
}
