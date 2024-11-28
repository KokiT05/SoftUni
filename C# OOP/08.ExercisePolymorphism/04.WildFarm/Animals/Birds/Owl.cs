using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double BaseWeightModifier = 0.25;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, allowedFoods, BaseWeightModifier, wingSize)
        {
        } 

        public override string Sound()
        {
            return $"Hoot Hoot";
        }
    }
}
