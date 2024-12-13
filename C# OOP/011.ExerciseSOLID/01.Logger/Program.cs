﻿using _01.LoggerExercise.Appenders;
using _01.LoggerExercise.Layouts;
using _01.LoggerExercise.Loggers;

namespace _01.LoggerExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}