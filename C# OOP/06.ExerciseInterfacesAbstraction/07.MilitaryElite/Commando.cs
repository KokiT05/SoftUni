using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    public class Commando : ICommando
    {
        private readonly List<IMissions> missions;
        public Commando(string id,
                        string firstName,
                        string lastName,
                        decimal salary,
                        string corps)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Corps = corps;
            this.missions = new List<IMissions>();

        }
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public decimal Salary { get; private set; }
        public string Corps { get; private set; }

        public IReadOnlyList<IMissions> Missions { get { return this.missions; }}

        public void AddMission(IMissions mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
            .AppendLine
            ($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary}");
            stringBuilder.AppendLine($"Corps: {this.Corps}");
            stringBuilder.AppendLine($"Missions:");
            foreach (IMissions mission in this.missions)
            {
                stringBuilder.AppendLine(mission.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
