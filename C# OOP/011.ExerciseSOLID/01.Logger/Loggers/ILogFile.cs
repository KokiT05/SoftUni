using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LoggerExercise.Loggers
{
    public interface ILogFile
    {
        int Size { get; }
        void Write(string content);
    }
}
