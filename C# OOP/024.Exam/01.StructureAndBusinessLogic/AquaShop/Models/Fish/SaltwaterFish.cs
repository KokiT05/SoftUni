using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int InitialSizeDefaultValue = 5;
        private const int IncreasesSizeDefaultValue = 2;
        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            base.Size = InitialSizeDefaultValue;
        }

        public override void Eat()
        {
            base.Size += IncreasesSizeDefaultValue;
        }
    }
}
