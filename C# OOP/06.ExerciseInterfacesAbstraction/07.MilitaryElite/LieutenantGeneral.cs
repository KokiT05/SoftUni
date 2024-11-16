using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    public class LieutenantGeneral : ILieutenantGeneral
    {
        private readonly List<IPrivate> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.privates = new List<IPrivate>();
        }
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public decimal Salary { get; private set; }

        public IReadOnlyList<IPrivate> Privates { get { return this.privates; } }

        public void AddPrivate(IPrivate privates)
        {
            this.privates.Add(privates);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.AppendLine(base.ToString());
            stringBuilder.
            AppendLine
            ($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary}");

            foreach (IPrivate @private in this.privates)
            {
                stringBuilder.AppendLine(@private.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
