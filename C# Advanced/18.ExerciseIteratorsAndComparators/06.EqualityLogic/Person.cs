using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace _06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person? other)
        {
            if (this.Name.ToLower() == other.Name.ToLower())
            {
                return this.Age.CompareTo(other.Age);
            }

            return this.Name.ToLower().CompareTo(other.Name.ToLower());
        }

        public override bool Equals(object inputObject)
        {
            //if (inputObject == null || !(inputObject is Person))
            //{
            //    return false;
            //}

            //Person otherPerson = (Person)inputObject;
            //bool isEquals = 
            //(this.Name.ToLower() == otherPerson.Name.ToLower() && this.Age == otherPerson.Age);
            //return isEquals;

            return this.GetHashCode() == inputObject.GetHashCode();
        }

        public override int GetHashCode()
        {
            int nameHash = this.Name.GetHashCode();
            int ageHash = this.Age.GetHashCode();
            return nameHash + ageHash;
            //string name = this.Name.ToLower();
            //int charSum = 0;
            //for (int i = 0; i < name.Length; i++)
            //{
            //    charSum += (name[i] * i + name[i]) * name[i];
            //}

            //int nameHashCode = charSum * name.Length;
            //int ageHashCode = this.Age.GetHashCode();

            //int personHashCode = nameHashCode ^ ageHashCode;

            //return personHashCode;
        }
    }
}
