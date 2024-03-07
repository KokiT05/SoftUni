using System;

namespace _11.Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;
            double snowballValue = 0;

            double highestSnowball = 0;
            int highestSnowballSnow = 0;
            int highestSnowballTime = 0;
            int highestSnowballQuality = 0;
            double highestSnowballValue = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                snowballSnow = int.Parse(Console.ReadLine());
                snowballTime = int.Parse(Console.ReadLine());
                snowballQuality = int.Parse(Console.ReadLine());

                snowballValue = Math.Pow((snowballSnow / snowballTime), snowballQuality);

                if (snowballValue > highestSnowball)
                {
                    highestSnowball = snowballValue;
                    highestSnowballSnow = snowballSnow;
                    highestSnowballQuality = snowballQuality;
                    highestSnowballTime = snowballTime;
                    highestSnowballValue = snowballValue;

                }
            }


            Console.WriteLine($"{highestSnowballSnow} : {highestSnowballTime} = {highestSnowballValue} ({highestSnowballQuality})");
        }
    }
}
