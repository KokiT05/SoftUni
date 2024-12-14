using _01.LoggerExercise.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LoggerExercise.Core.Factories
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
