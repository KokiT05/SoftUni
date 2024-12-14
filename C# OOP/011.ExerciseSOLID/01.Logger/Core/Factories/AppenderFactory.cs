using _01.LoggerExercise.Appenders;
using _01.LoggerExercise.Enums;
using _01.LoggerExercise.Layouts;
using _01.LoggerExercise.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LoggerExercise.Core.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {
            IAppender appender;

            switch (type)
            {
                case nameof(ConsoleAppender): 
                        appender = new ConsoleAppender(layout) { ReportLevel = reportLevel };
                    break;
                case nameof(FileAppender): 
                        appender = new FileAppender(layout, new LogFile()) { ReportLevel = reportLevel};
                    break;
                default:
                    throw new ArgumentException($"{type} is invalid Appender type.");
                    break;
            }

            return appender;
        }
    }
}
