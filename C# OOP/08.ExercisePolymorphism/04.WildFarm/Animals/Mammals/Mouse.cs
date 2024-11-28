using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double BaseWeightModifier = 0.10;
        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Vegetable),
            nameof(Fruit),
        };
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, allowedFoods, BaseWeightModifier, livingRegion)
        {
        }

        public override string Sound()
        {
            return $"Squeak";
        }


    }
}
