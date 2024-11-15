using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ExplicitInterfaces
{
    public interface IPerson
    {
        string Name { get; set; }

        int Age { get; set; }

        string GetName();
    }
}
