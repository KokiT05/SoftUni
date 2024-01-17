﻿using System;

namespace _03.Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            int number = 0;
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    p1++;
                }
                else if (number >= 200 && number < 400)
                {
                    p2++;
                }
                else if (number >= 400 && number < 600)
                {
                    p3++;
                }
                else if (number >= 600 && number < 800)
                {
                    p4++;
                }
                else if (number >= 800)
                {
                    p5++;
                }
            }

            Console.WriteLine($"{((p1 / n ) * 100):f2}%");
            Console.WriteLine($"{((p2 / n ) * 100):f2}%");
            Console.WriteLine($"{((p3 / n ) * 100):f2}%");
            Console.WriteLine($"{((p4 / n ) * 100):f2}%");
            Console.WriteLine($"{((p5 / n ) * 100):f2}%");

            //Console.WriteLine(Math.Round((p1 / n) * 100, 2));
            //Console.WriteLine(Math.Round((p2 / n) * 100, 2));
            //Console.WriteLine(Math.Round((p3 / n) * 100, 2));
            //Console.WriteLine(Math.Round((p4 / n) * 100, 2));
            //Console.WriteLine(Math.Round((p5 / n) * 100, 2));
        }
    }
}
