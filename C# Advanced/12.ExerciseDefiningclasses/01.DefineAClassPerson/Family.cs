using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person person)
        {
            People.Add(person);
        }

        public Person GetOldestMember()
        {
            People = People.OrderByDescending(p => p.Age).ToList();
            return People.First();
        }
    }
}
