﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        private const int PaladinPaladin = 100;
        public Paladin(string name) : base(name, PaladinPaladin)
        {
            
        }

        public override string CastAbility()
        {
            return $"{nameof(Paladin)} - {this.Name} healed for {this.Power}";
        }
    }
}
