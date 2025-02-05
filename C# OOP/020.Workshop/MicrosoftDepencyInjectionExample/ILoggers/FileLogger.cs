using MicrosoftDepencyInjectionExample.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDepencyInjectionExample.ILoggers
{
    public class FileLogger : ILogger
    {
        private string path;
        public FileLogger(string path)
        {
            this.path = path;
        }
        public void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
