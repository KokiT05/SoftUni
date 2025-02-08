using _020.Workshop.DI.Attributes;
using _020.Workshop.DI.Containers;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop.DI
{
    public class Injector
    {
        private IContainer container;
        public Injector(IContainer container)
        {
            this.container = container;
        }

        public TClass Inject<TClass>()
        {
            if (!this.HasConstructorInjection<TClass>())
            {
                return (TClass)Activator.CreateInstance(typeof(TClass));
                //throw new ArgumentException
                //("The class has no constructor annoted with the [Inject] attribute");
            }

            return this.CreateConstructorInjection<TClass>();
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            ConstructorInfo[] constructors = typeof(TClass).GetConstructors();

            if (constructors.Length > 1)
            {
                throw new ArgumentException("Only one constructor is allowed");
            }

            foreach (ConstructorInfo constructor in constructors)
            {
                //if (constructor.GetCustomAttribute(typeof(Inject), true) == null)
                //{
                //    continue;
                //}

                ParameterInfo[] constructorParameters = constructor.GetParameters();
                object[] constructorParameterObjects = new object[constructorParameters.Length];
                int i = 0;

                foreach (ParameterInfo parameterInfo in constructorParameters)
                {
                    object implementationInstance = GetImplementation(parameterInfo.ParameterType);

                    constructorParameterObjects[i++] = implementationInstance;
                }

                return (TClass)Activator.CreateInstance(typeof(TClass), constructorParameterObjects);
            }

            return default;
        }

        private bool HasConstructorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(c => c.GetParameters().Length != 0);
        }

        private object CallGenericMethod(Type implementation)
        {
            MethodInfo injectMethod = typeof(Injector).GetMethod("Inject");
            injectMethod = injectMethod.MakeGenericMethod(implementation);

            return injectMethod.Invoke(this, new object[] { });
        }

        private object GetImplementation(Type type)
        {
            Type interfaceType = type;
            Type implementation = container.GetMapping(interfaceType);

            object implementationInstance;
            if (implementation == null)
            {
                var implementationPair = container.GetCustomMapping(interfaceType);
                implementationInstance = implementationPair.Value();
            }
            else
            {
                implementationInstance = CallGenericMethod(implementation);
            }

            return implementationInstance;
        }
    }
}
