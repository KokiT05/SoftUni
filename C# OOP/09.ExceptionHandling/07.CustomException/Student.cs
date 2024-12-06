using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CustomException
{
    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            this.Name = name;
            this.email = email;
        }
        public string Name
        {
            get => name; 
            private set
            {
                if (!(IsValidName(value)))
                {
                    throw new InvalidPersonNameException
                        ("Not allow any special character or numeric value in a name");
                }
            }
        }

        public string Email { get => this.email; private set => this.email = value; }

        private bool IsValidName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (!(char.IsLetter(name[i])))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
