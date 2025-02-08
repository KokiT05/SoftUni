using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop.DI.Containers
{
    public interface IContainer
    {
        void ConfigureServices();

        void CreateMapping<TInterfaceType, TImplementationType>();
        void CreateMapping<TInterfaceType, TImplementationType>(Func<object> creationFunc);

        Type GetMapping(Type interfaceType);
        KeyValuePair<Type, Func<object>> GetCustomMapping(Type interfaceType);
    }
}
