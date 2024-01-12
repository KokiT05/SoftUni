using System;

namespace _10.InvalidNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool flag = (number >= 100 && number <= 200) || number == 0;
            if (!flag)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
