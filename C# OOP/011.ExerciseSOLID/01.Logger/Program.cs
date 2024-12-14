using _01.LoggerExercise.Appenders;
using _01.LoggerExercise.Core.Factories;
using _01.LoggerExercise.Enums;
using _01.LoggerExercise.Layouts;
using _01.LoggerExercise.Loggers;

namespace _01.LoggerExercise
{
    internal class Program
    {
        private static IAppenderFactory appenderFactory;
        private static ILayoutFactory layoutFactory;


        static void Main(string[] args)
        {
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

            appenderFactory = new AppenderFactory();
            layoutFactory = new LayoutFactory();

            int n = int.Parse(Console.ReadLine());
            IAppender[] appenders = ReadAppenders(n);

            Logger logger = new Logger(appenders);

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
                ReportLevel reportLevel = Enum.Parse<ReportLevel>(parts[0], true);
                string date = parts[1];
                string message = parts[2];

                switch (reportLevel)
                {
                    case ReportLevel.Info:
                        logger.Info(date, message);
                        break;
                    case ReportLevel.Warning:
                        logger.Warning(date, message);
                        break;
                    case ReportLevel.Error:
                        logger.Error(date, message);
                        break;
                    case ReportLevel.Critical:
                        logger.Critical(date, message);
                        break;
                    case ReportLevel.Fatal:
                        logger.Fatal(date, message);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(logger.ToString());
        }

        private static IAppender[] ReadAppenders(int n)
        {
            IAppender[] appenders = new IAppender[n];
            for (int i = 0; i < 2; i++)
            {
                string[] appenderParts = Console.ReadLine().Split();
                string appenderType = appenderParts[0];
                string layoutType = appenderParts[1];
                ReportLevel reportLevel = appenderParts.Length == 3
                    ? Enum.Parse<ReportLevel>(appenderParts[2], true) : ReportLevel.Info;

                ILayout layout = layoutFactory.CreateLayout(layoutType);
                IAppender appender =
                    appenderFactory.CreateAppender(appenderType, layout, reportLevel);
                appenders[i] = (appender);
            }

            return appenders;
        }
    }
}
