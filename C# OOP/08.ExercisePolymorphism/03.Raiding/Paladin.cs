using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        private int paladinPaladin = 100;
        public Paladin(string name) : base(name)
        {
            
        }
        public override int Power { get { return this.paladinPaladin; } }

        public override string CastAbility()
        {
            return $"{nameof(Paladin)} - {this.Name} healed for {this.Power}";
        }
    }
}
