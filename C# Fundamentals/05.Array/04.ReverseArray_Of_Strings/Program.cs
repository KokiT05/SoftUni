using System;
using System.Linq;

namespace _04.ReverseArray_Of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mathod 1
            //Console.WriteLine(string.Join(' ', Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse()));

            string input = Console.ReadLine();
            string[] stringArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string olderChar = " ";
            for (int i = 0; i < stringArray.Length / 2; i++)
            {
                olderChar = stringArray[i];
                stringArray[i] = stringArray[stringArray.Length - 1 - i];
                stringArray[stringArray.Length - 1 - i] = olderChar;
            }

            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.Write($"{stringArray[i]} ");
            }
        }
    }
}
