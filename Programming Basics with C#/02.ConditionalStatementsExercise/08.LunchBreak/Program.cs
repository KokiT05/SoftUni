using System;

namespace _08.LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seriesName =  Console.ReadLine();
            double episodeDuration = double.Parse(Console.ReadLine());
            double durationRest = double.Parse(Console.ReadLine());

            double timeLunch = durationRest * 1 / 8;
            double timeRelax = durationRest * 1 / 4;

            double totalTime = durationRest - (timeLunch + timeRelax);

            double result = Math.Abs(totalTime - episodeDuration);
            result = Math.Ceiling(result);
            if (totalTime >= episodeDuration)
            {
                Console.WriteLine($"You have enough time to watch {seriesName} and left with {result} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {result} more minutes.");
            }
        }
    }
}
