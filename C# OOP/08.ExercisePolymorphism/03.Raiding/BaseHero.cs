using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public abstract class BaseHero
    {
        private string name;
        //private int power;
        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
            //this.Power = power;
        }

        public  string Name { get; private set; }

        public int Power { get; private set; }

        public abstract string CastAbility();
    }
}
