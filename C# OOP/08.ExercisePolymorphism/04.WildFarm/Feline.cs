using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Feline : Mammal
    {
        public Feline(string name, double weight, int foodEaten, string livingRegion, string Breed) 
            : base(name, weight, foodEaten, livingRegion)
        {
        }

        public string Breed { get; private set; }

        public override string Sound()
        {
            return base.Sound();
        }
    }
}
