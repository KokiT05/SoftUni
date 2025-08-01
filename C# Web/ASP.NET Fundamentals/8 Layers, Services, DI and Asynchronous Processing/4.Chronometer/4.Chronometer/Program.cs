﻿using System.Diagnostics;
using System.Globalization;

namespace _4.Chronometer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chronometer chronometer = new Chronometer();

            string line;

            while ((line = Console.ReadLine()) != "exit")
            {
                if (line == "start")
                {
                    Task.Run(() =>
                    {
                        chronometer.Start();
                    });
                }
                else if (line == "stop")
                {
                    chronometer.Stop();
                }
                else if (line == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (line == "laps")
                {
                    if (chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine("Laps: no laps");
                        continue;
                    }
                    Console.WriteLine("Laps: ");
                    for (int i = 0; i < chronometer.Laps.Count; i++)
                    {
                        Console.WriteLine($"{i} {chronometer.Laps[i]}");
                    }
                }
                else if (line == "reset")
                {
                    chronometer.Reset();
                }
                else if (line == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
            }
            chronometer.Stop();
        }
    }
}
