using System;

namespace _08.CinemaTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dayOgWeek = Console.ReadLine();
            dayOgWeek = dayOgWeek.ToLower();

            switch (dayOgWeek)
            {
                case "monday":
                case "tuesday":
                case "friday":
                    Console.WriteLine(12);
                    break;
                case "wednesday":
                case "thursday":
                    Console.WriteLine(14);
                    break;
                case "saturday":
                case "sunday":
                    Console.WriteLine(16);
                    break;
            }
        }
    }
}
