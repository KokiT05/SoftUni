﻿using System;

namespace _03.Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)numberOfPeople / capacity);
            //int remainder = numberOfPeople - (courses * capacity);

            //if (remainder / capacity == 0 && remainder != 0)
            //{
            //    courses++;
            //}

            Console.WriteLine($"{courses}");
        }
    }
}
