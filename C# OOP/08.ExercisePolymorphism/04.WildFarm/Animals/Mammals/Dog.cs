using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double BaseWeightModifier = 0.40;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, allowedFoods, BaseWeightModifier, livingRegion)
        {
        }

        public override string Sound()
        {
            return $"Woof!";
        }
    }
}
