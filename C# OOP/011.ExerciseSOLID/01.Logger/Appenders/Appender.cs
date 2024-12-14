using _01.LoggerExercise.Enums;
using _01.LoggerExercise.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LoggerExercise.Appenders
{
    public abstract class Appender : IAppender
    {
        protected readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        protected int MessagesCount { get; set; }

        public abstract void Append(string date, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}," +
                $"Report level: {this.ReportLevel}, Messages appended: {this.MessagesCount}";
        }

        protected bool CanAppend(ReportLevel reportLevel)
        {
            return reportLevel >= this.ReportLevel;
        }
    }
}
