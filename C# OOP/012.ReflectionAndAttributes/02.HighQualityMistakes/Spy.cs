using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02.HighQualityMistakes
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

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static
                | BindingFlags.Public);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = 
                classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder result = new StringBuilder();

            foreach (FieldInfo field in fields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                result.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                result.AppendLine($"{method.Name} have to be private!");
            }


            return result.ToString().TrimEnd();
        }
    }
}
