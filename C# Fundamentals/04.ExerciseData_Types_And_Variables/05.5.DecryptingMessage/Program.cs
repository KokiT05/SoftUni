using System;

namespace _05._5.DecryptingMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string messages = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                char character = char.Parse(Console.ReadLine());
                messages += (char)(character + key);
            }

            Console.WriteLine(messages);
        }
    }
}
