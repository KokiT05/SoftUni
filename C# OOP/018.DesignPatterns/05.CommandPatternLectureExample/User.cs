using _05.CommandPatternLectureExample.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CommandPatternLectureExample
{
    public class User
    {
        public User(Calculator calculator)
        {
            this.Calculator = calculator;
        }
 
        public Calculator Calculator { get; set; }

        public void Calculate(char sing, decimal value)
        {
            switch (sing)
            {
                case '+': Calculator.Execute(new AddCommand(value));
                    break;
                case '-': Calculator.Execute(new MinusCommand(value));
                    break;
                case '*': Calculator.Execute(new MultiplyCommand(value));
                    break;
                case '/': Calculator.Execute(new DivideCommand(value)); break;
                default:
                    break;
            }
        }

    }
}
