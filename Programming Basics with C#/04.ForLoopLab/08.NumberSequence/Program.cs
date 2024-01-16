﻿using System;

namespace _08.NumberSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minNumber = int.MaxValue;
            int maxNumber = int.MinValue;
            int number = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());

                if (number < minNumber)
                {
                    minNumber = number;
                }

                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            Console.WriteLine($"Max number: {maxNumber}");
            Console.WriteLine($"Min number: {minNumber}");
        }
    }
}
