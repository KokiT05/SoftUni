using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _06.CodeTracker
{
    public class Tracker
    {
        public void PrintMethodByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = 
                type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    object[] attributeCollection = method.GetCustomAttributes(false);
                    //foreach (AuthorAttribute attribute in attributeCollection
                    //    .Where(a => a.GetType().Name.StartsWith("Author")))
                    //{
                    //    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    //} //

                    foreach (AuthorAttribute attribute in attributeCollection)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
