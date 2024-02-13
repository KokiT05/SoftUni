using System;

namespace _07.ConcatNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string sumbol = string.Empty;
            //string text = string.Empty;

            //for (int i = 1; i <= 3; i++)
            //{
            //    if (i != 3)
            //    {
            //        sumbol = Console.ReadLine();
            //    }
            //    text += sumbol;
            //}

            //Console.WriteLine(text);

            string firsrName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string delimiter = Console.ReadLine();

            Console.WriteLine($"{firsrName}{delimiter}{secondName}");
        }
    }
}
