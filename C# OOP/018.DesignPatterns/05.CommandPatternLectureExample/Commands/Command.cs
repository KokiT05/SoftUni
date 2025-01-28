using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CommandPatternLectureExample.Commands
{
    public abstract class Command : ICommand
    {
        public Command(decimal currentValue)
        {
            this.CurrentValue = currentValue;
        }

        public decimal CurrentValue { get; set; }

        public abstract decimal Execute(decimal value);

        public abstract decimal Unexecute(decimal value);
    }
}
