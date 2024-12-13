using _01.LoggerExercise.Enums;
using _01.LoggerExercise.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LoggerExercise.Appenders
{
    public interface IAppender
    {
        public void Append(string date, ReportLevel reportLevel, string message);
    }
}
