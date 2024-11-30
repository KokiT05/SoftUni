using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.WildFarm.Animals;

namespace _04.WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, 
            double weight,  
            HashSet<string> allowedFoods, 
            double weightModifier,
            string livingRegion) 
            : base(name, weight, allowedFoods, weightModifier)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, " +
                $"{this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
