using System;
using System.Diagnostics;
using System.Linq;

namespace _02.CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstInputArray = Console
                                        .ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] secondInputArray = Console
                                        .ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commonString = string.Empty;

            string currentStringFirstArray = string.Empty;
            string currentStringSecondArray = string.Empty;

            for (int i = 0; i < secondInputArray.Length; i++)
            {
                currentStringSecondArray = secondInputArray[i];

                for (int j = 0; j < firstInputArray.Length; j++)
                {
                    currentStringFirstArray = firstInputArray[j];

                    if (currentStringFirstArray == currentStringSecondArray)
                    {
                        commonString += " " + secondInputArray[i];
                        break;
                    }
                }
            }

            Console.WriteLine($"{commonString.TrimStart()}");
        }
    }
}
