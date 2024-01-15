using System;

namespace _08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int allMinutesExamTime = 0;
            int allMinutesArrival = 0;

            int examTime = int.Parse(Console.ReadLine());
            int minutesPerExam = int.Parse(Console.ReadLine());
            int hourOfArrival = int.Parse(Console.ReadLine());
            int minutesOfArrival = int.Parse(Console.ReadLine());

            allMinutesExamTime = (examTime * 60) + minutesPerExam;
            allMinutesArrival = (hourOfArrival * 60) + minutesOfArrival;

            int result = allMinutesExamTime - allMinutesArrival;

            if (result == 0)
            {
                Console.WriteLine("On time");
            }
            else if (result > 0 && result <= 30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{result} minutes before the start");
            }
            else if (result > 30 && result < 60)
            {
                Console.WriteLine("Early");
                Console.WriteLine($"{result} minutes before the start");
            }
            else if (result >= 60)
            {
                 int hour = result / 60;
                 int minutes = result % 60;
                Console.WriteLine("Early");

                if (minutes < 10)
                {
                    Console.WriteLine($"{hour}:0{minutes} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{hour}:{minutes} hours before the start");
                }
            }
            else if (result < 0 && result >= -59)
            {
                result = Math.Abs(result);
                Console.WriteLine("Late");
                Console.WriteLine($"{result} minutes after the start");
            }
            else if (result < -59)
            {
                result = Math.Abs(result);
                int hour = result / 60;
                int minutes = result % 60;
                Console.WriteLine("Late");

                if (minutes < 10)
                {
                    Console.WriteLine($"{hour}:0{minutes} hours after the start");
                }
                else
                {
                    Console.WriteLine($"{hour}:{minutes} hours after the start");
                }
            }
        }
    }
}
