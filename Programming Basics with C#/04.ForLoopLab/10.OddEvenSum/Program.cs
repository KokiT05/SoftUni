﻿using System;
using System.Security.Cryptography;

namespace _10.OddEvenSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oddSumIndex = 0;
            int evenSumIndex = 0;
            int number = 0;

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                number = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSumIndex += number;
                }
                else
                {
                    oddSumIndex += number;
                }
            }

            if (oddSumIndex == evenSumIndex)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {oddSumIndex}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(oddSumIndex - evenSumIndex)}");
            }
        }
    }
}
