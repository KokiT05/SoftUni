using System;

namespace _06.VowelsSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int e = 2;
            int i = 3;
            int o = 4;
            int u = 5;
            int sum = 0;

            string text = Console.ReadLine();
            for (int j = 0; j < text.Length; j++)
            {
                char letter = text[j];
                switch (letter)
                {
                    case 'a':
                        sum += a;
                        break;
                    case 'e':
                        sum += e;
                        break;
                    case 'i':
                        sum += i;
                        break;
                    case 'o':
                        sum += o;
                        break;
                    case 'u':
                        sum += u;
                        break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
