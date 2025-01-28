using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CommandPatternLectureExample.Commands
{
    public interface ICommand
    {
        decimal Execute(decimal value);

        decimal Unexecute(decimal value);
    }
}
