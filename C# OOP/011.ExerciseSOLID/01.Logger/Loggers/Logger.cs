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
        private readonly IAppender[] appenders;
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string date, string message)
        {
            this.AppendToAppenders(date, ReportLevel.Info, message);
        }

        public void Warning(string date, string message)
        {
            this.AppendToAppenders(date, ReportLevel.Warning, message);
        }

        public void Error(string date, string message)
        {
            this.AppendToAppenders(date, ReportLevel.Error, message);
        }

        public void Critical(string date, string message)
        {
            this.AppendToAppenders(date, ReportLevel.Critical, message);
        }

        public void Fatal(string date, string message)
        {
            this.AppendToAppenders(date, ReportLevel.Fatal, message);
        }

        private void AppendToAppenders(string date, ReportLevel reportLevel, string message)
        {
            foreach(IAppender appender in this.appenders)
            {
                appender.Append(date, reportLevel, message);
            }
        }
    }
}
