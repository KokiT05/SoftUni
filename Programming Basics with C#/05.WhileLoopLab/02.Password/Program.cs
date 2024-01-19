using System;

namespace _02.Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string text = Console.ReadLine();

            while (password != text)
            {
                text = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {username}!");
        }
    }
}
