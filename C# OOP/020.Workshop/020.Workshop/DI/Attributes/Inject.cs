using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop.DI.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class Inject : Attribute
    {
    }
}
