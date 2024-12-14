using _01.LoggerExercise.Enums;
using _01.LoggerExercise.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LoggerExercise.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base (layout)
        {
            
        }
        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (!(this.CanAppend(reportLevel)))
            {
                return;
            }

            this.MessagesCount += 1;

            string content = string.Format(this.layout.Template, date, reportLevel, message);
            Console.WriteLine(content);
        }
    }
}
