using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        private const int DruidPower = 80;
        public Druid(string name) : base (name, DruidPower)
        {
        }
        public override string CastAbility()
        {
            return $"{nameof(Druid)} - {this.Name} healed for {this.Power}";
        }
    }
}
