using _020.Workshop.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop.ILoggers
{
    public class FileLogger : ILogger
    {
        public FileLogger()
        {
            
        }
        public void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../logs.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
