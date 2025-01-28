using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05.CommandPatternLectureExample.Commands;

namespace _05.CommandPatternLectureExample
{
    public class Calculator 
    {
        private Stack<ICommand> commands;

        public Calculator()
        {
            commands = new Stack<ICommand>();
        }

        public decimal CurrentValue { get; set; }

        public void Execute(ICommand command)
        {
            CurrentValue = command.Execute(CurrentValue);
            commands.Push(command);
        }

        public void Undo(int level)
        {
            for (int i = 0; i < level; i++)
            {
                if (commands.Count > 0)
                {
                    CurrentValue = commands.Pop().Unexecute(CurrentValue);
                }
            }
        }
    }
}
