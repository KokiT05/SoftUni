using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop.DI.Containers
{
    public abstract class AbstractContainer : IContainer
    {
        private Dictionary<Type, Type> mappings;
        private Dictionary<Type, KeyValuePair<Type, Func<object>>> mappingsWithCustomCreation;

        protected AbstractContainer()
        {
            mappings = new Dictionary<Type, Type>();
            mappingsWithCustomCreation = new Dictionary<Type, KeyValuePair<Type, Func<object>>>();
        }

        public abstract void ConfigureServices();

        public void CreateMapping<TInterfaceType, TImplementationType>()
        {
            CheckIsAssinableFrom<TInterfaceType, TImplementationType>();
            this.mappings[typeof(TInterfaceType)] = typeof(TImplementationType);
        }

        public void CreateMapping<TInterfaceType, TImplementationType>(Func<object> creationFunc)
        {

            CheckIsAssinableFrom<TInterfaceType, TImplementationType>();
            this.mappingsWithCustomCreation[typeof(TInterfaceType)] = 
                new KeyValuePair<Type, Func<object>>(typeof(TImplementationType), creationFunc);
        }

        public Type GetMapping(Type interfaceType)
        {
            if (!mappings.ContainsKey(interfaceType))
            {
                return null;
            }

            return this.mappings[interfaceType];
        }

        public KeyValuePair<Type, Func<object>> GetCustomMapping(Type interfaceType)
        {
            return this.mappingsWithCustomCreation[interfaceType];
        }
        private void CheckIsAssinableFrom<TInterfaceType, TImplementationType>()
        {
            if (!typeof(TInterfaceType).IsAssignableFrom(typeof(TImplementationType)))
            {
                throw new ArgumentException
                    ($"{typeof(TImplementationType).Name} is not assignle from {typeof(TInterfaceType).Name}");
            }
        }
    }
}
