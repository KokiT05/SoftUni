using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LoggerExercise.Core.IO
{
    public class FileReader : IReader
    {
        private readonly string[] fileLines;
        private int pointer;

        public FileReader(string path = "../../../input.txt")
        {
            this.fileLines = File.ReadAllLines(path);
        }
        public string ReadLine()
        {
            return this.fileLines[pointer++];
        }
    }
}
