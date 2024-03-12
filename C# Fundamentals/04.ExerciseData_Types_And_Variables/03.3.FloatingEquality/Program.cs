using System;
using System.ComponentModel.Design;

namespace _03._3.FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double eps = 0.000001;

            double firstFloatingPointNumber = double.Parse(Console.ReadLine());
            double secondFloatingPointNumber = double.Parse(Console.ReadLine());
            double result = Math.Abs(firstFloatingPointNumber - secondFloatingPointNumber);

            if (result < eps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
