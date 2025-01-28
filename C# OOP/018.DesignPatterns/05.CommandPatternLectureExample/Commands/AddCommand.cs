using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CommandPatternLectureExample.Commands
{
    public class AddCommand : Command
    {
        public AddCommand(decimal currentValue) : base(currentValue)
        {
        }

        public override decimal Execute(decimal value)
        {
            return value + base.CurrentValue;
        }

        public override decimal Unexecute(decimal value)
        {
            return value - base.CurrentValue;
        }
    }
}
