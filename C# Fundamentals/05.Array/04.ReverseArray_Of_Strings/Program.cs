using System;
using System.Linq;

namespace _04.ReverseArray_Of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(' ', Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse()));
        }
    }
}
