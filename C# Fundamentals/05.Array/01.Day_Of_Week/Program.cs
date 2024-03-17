using System;

namespace _01.Day_Of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());

            string[] dayOfWeek = new string[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            if (day < 1 || day > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(dayOfWeek[day-1]);
            }


        }
    }
}
