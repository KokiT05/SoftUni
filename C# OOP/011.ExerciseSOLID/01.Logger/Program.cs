﻿using _01.LoggerExercise.Appenders;
using _01.LoggerExercise.Core;
using _01.LoggerExercise.Core.Factories;
using _01.LoggerExercise.Core.IO;
using _01.LoggerExercise.Enums;
using _01.LoggerExercise.Layouts;
using _01.LoggerExercise.Loggers;

namespace _01.LoggerExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAppenderFactory appenderFactory = new AppenderFactory();
            ILayoutFactory layoutFactory = new LayoutFactory();
            IReader reader = new FileReader();

            IEngine engine = new Engine(appenderFactory, layoutFactory, reader);
            engine.Run();

            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new FileAppender(simpleLayout);
            //ILogger logger = new Logger(consoleAppender);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //var layout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(layout);


            //var file = new LogFile();
            //var fileAppender = new FileAppender(layout, file);

            //var logger = new Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //var xmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(xmlLayout);
            //var logger = new Logger(consoleAppender);

            //logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            //logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");

            //var simpleLayout = new JsonLayout();
            //var consoleAppender = new FileAppender(simpleLayout, new LogFile());
            //consoleAppender.ReportLevel = ReportLevel.Error;

            //var logger = new Logger(consoleAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

        }
    }
}
