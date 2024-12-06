using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CustomException
{
    public class InvalidPersonNameException : Exception
    {
        private string message;
        public InvalidPersonNameException(string message)
        {
            this.message = message;
        }

        //public override Me
        public override string Message { get => this.message; }
    }
}
