using _01.SoftUniDIFrameworkLibrary.Injectors;
using _01.SoftUniDIFrameworkLibrary.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SoftUniDIFrameworkLibrary
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
