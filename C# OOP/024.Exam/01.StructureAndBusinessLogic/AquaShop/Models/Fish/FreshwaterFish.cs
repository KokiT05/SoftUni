using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int IncreasesDefaultValue = 3;
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            base.Size = IncreasesDefaultValue;
        }

        public override void Eat()
        {
            base.Size += IncreasesDefaultValue;
        }
    }
}
