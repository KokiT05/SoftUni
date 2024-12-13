using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LoggerExercise.Loggers
{
    public class LogFile : ILogFile
    {
        private const string FilePath = "../../../log.txt";
        public int Size => File.ReadAllText(FilePath).Where(c => char.IsLetter(c)).Sum(c => c);

        public void Write(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}
