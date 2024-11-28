using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double BaseWeightModifier = 0.30;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Meat),
        };

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, allowedFoods, BaseWeightModifier, livingRegion, breed)
        {
        }

        public override string Sound()
        {
            return $"Meow";
        }
    }
}
