using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FirstAndReserveTeam
{
    public class Team
    {
        private string name;
        private readonly List<Person> firstTeam;
        private readonly List<Person> reserveTeam;

        public Team(string name)
        {
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
            this.Name = name;
        }

        public string Name { get; set; }

        public IReadOnlyList<Person> FirstTeam 
        { get { return this.firstTeam.AsReadOnly(); } }
        public IReadOnlyList<Person> ReserveTeam 
        { get { return this.reserveTeam.AsReadOnly(); } }

        public List<Person> TestTeam { get; private set; }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }
}
