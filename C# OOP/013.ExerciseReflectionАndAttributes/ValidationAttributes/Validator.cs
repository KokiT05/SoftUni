using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object @object)
        {
            //Type type = @object.GetType();
            //PropertyInfo[] properties = type.GetProperties()
            //                            .ToArray();

            PropertyInfo[] properties = @object.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute[] attributes = property.GetCustomAttributes()
                                                    .Cast<MyValidationAttribute>()
                                                    .ToArray();

                object? value = property.GetValue(@object);

                foreach (MyValidationAttribute attribute in attributes)
                {
                    bool isValid = attribute.IsValid(value);
                    if (!isValid)
                    {
                        return false;
                    }
                }
            } 

            return true;
        }
    }
}
