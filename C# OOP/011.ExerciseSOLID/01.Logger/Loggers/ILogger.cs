﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LoggerExercise.Loggers
{
    public interface ILogger
    {
        void Info(string date, string message);
        void Warning(string date, string message);
        void Error(string date, string message);
        void Critical(string date, string message);
        void Fatal(string date, string message);
    }
}
