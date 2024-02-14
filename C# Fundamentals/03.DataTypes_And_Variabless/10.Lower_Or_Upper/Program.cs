using System;
using System.Globalization;

namespace _10.Lower_Or_Upper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool isLower = false;
            //bool isUpper = false;

            char sumbol = char.Parse(Console.ReadLine());

            string sumbolString = sumbol.ToString();

            if (sumbolString.ToLower() == sumbolString)
            {
                //isLower = true;
                Console.WriteLine("lower-case");
            }
            else if (sumbolString.ToUpper() == sumbolString)
            {
                //isUpper = true;
                Console.WriteLine("upper-case");
            }

            //if (isUpper)
            //{
            //    Console.WriteLine("upper-case");
            //}

            //if (isLower)
            //{
            //    Console.WriteLine("lower-case");
            //}
        }
    }
}
