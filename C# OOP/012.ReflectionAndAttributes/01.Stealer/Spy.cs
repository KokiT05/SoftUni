using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01.Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Static | BindingFlags.Public);

            StringBuilder result = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] {});

            result.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in fieldsInfo.Where(f => fields.Contains(f.Name)))
            {
                result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }



            return result.ToString().TrimEnd();
        }
    }
}
