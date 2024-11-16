using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    public class Engineer : IEngineer
    {
        private readonly List<IRepair> repairs;
        public Engineer(string id, 
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
            this.repairs = new List<IRepair>();

        }
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public IReadOnlyList<IRepair> Repairs { get { return this.repairs; } }

        public string Corps { get; private set; }

        public decimal Salary { get; private set; }

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
            .AppendLine
            ($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary}");
            stringBuilder.AppendLine($"Corps: {this.Corps}");
            stringBuilder.AppendLine("Repairs:");
            foreach (IRepair repair in this.repairs)
            {
                stringBuilder.AppendLine(repair.ToString());
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
