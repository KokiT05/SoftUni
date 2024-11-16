using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    public class SpecialisedSoldier : ISpecialisedSoldier
    {

        private string corps;
        public SpecialisedSoldier(string id, 
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
        }
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Corps
        {
            get
            {
                return this.corps;
            }

            private set
            {
                //if (value != CorpsAirforces || value != CorpsMarines)
                //{

                //}

                this.corps = value;
            }
        }

        public decimal Salary { get; private set; }
    }
}
