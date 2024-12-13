using _01.LoggerExercise.Appenders;
using _01.LoggerExercise.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LoggerExercise.Loggers
{
    public class Logger : ILogger
    {
        private IAppender appender;
        public Logger(IAppender appender)
        {
            this.appender = appender;
        }
        public void Error(string date, string message)
        {
            this.appender.Append(date, ReportLevel.Error, message);
        }

        public void Info(string date, string message)
        {
            this.appender.Append(date, ReportLevel.Info, message);
        }
    }
}
