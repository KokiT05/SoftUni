using System;
using System.Xml.Schema;

namespace _02._2PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numRows = int.Parse(Console.ReadLine());

            int[] triangle = new int[numRows * (numRows + 1) / 2];
            int index = 0;

            for (int i = 0; i < numRows; i++)
            {
                int currentValue = 1;
                for (int j = 0; j <= i; j++)
                {
                    triangle[index++] = currentValue;
                    currentValue = currentValue * (i - j) / (j + 1);
                }
            }

            index = 0;
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(triangle[index++] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
