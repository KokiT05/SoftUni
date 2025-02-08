using _01.SoftUniDIFrameworkLibrary.Attributes;
using _01.SoftUniDIFrameworkLibrary.Modules;
using System.Formats.Asn1;
using System.Reflection;

namespace _01.SoftUniDIFrameworkLibrary.Injectors
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            bool hasConstructorAttribute = this.CheckForConstructorInjection<TClass>();
            bool hasFieldAttribute = this.CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException
                    ("There must be only field or constructor annotated with Inject attribute");
            }

            if (hasConstructorAttribute)
            {
                return this.CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttribute)
            {
                return this.CreateFieldsInjection<TClass>();
            }

            return default(TClass);
        }
        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(constructor => constructor.GetCustomAttribute(typeof(Inject), true).Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            Type desireClass = typeof(TClass);
            if (desireClass == null)
            {
                return default(TClass);
            }

            ConstructorInfo[] constructors = desireClass.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                if (!CheckForConstructorInjection<TClass>())
                {
                    continue;
                }

                object inject = (Inject)constructor
                            .GetCustomAttributes(typeof(Inject), true)
                            .FirstOrDefault();

                ParameterInfo[] parameterTypes = constructor.GetParameters();
                object[] constructorParameters = new object[parameterTypes.Length];

                int i = 0;
                foreach (ParameterInfo parameterType in parameterTypes)
                {
                    Attribute named = parameterType.GetCustomAttribute(typeof(Named));
                    Type dependency = null;

                    if (named == null)
                    {
                        dependency = this.module.GetMapping(parameterType.ParameterType, inject);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(parameterType.ParameterType, named);
                    }

                    if (parameterType.ParameterType.IsAssignableFrom(dependency))
                    {
                        object insantce = this.module.GetInstance(dependency);

                        if (insantce != null)
                        {
                            constructorParameters[i++] = insantce;
                        }
                        else
                        {
                            insantce = Activator.CreateInstance(dependency);
                            constructorParameters[i++] = insantce;
                            this.module.SetInstance(parameterType.ParameterType, insantce);
                        }
                    }
                }
                return (TClass)Activator.CreateInstance(desireClass, constructorParameters);
            }
            return default(TClass);
        }

        private TClass CreateFieldsInjection<TClass>()
        {
            Type desireClass = typeof(TClass);
            object desireClassInstance = this.module.GetInstance(desireClass);

            if (desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                this.module.SetInstance(desireClass, desireClassInstance);
            }

            FieldInfo[] fields = desireClass.GetFields((BindingFlags)62);
            foreach (FieldInfo field in fields)
            {
                if (field.GetCustomAttributes(typeof(Inject), true).Any())
                {
                    var injection = (Inject)field
                                    .GetCustomAttributes(typeof(Inject), true)
                                    .FirstOrDefault();
                    Type dependency = null;

                    Attribute named = field.GetCustomAttribute(typeof(Named), true);
                    Type type = field.FieldType;
                    if (named == null)
                    {
                        dependency = this.module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(type, named);
                    }

                    if (type.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstance(dependency);
                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            this.module.SetInstance(dependency, instance);
                        }

                        field.SetValue(desireClassInstance, instance);
                    }
                }
            }

            return (TClass)desireClassInstance;
        }
    }
}
