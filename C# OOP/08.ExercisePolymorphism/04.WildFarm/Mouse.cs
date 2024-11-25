using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, livingRegion)
        {
            this.Foods = new List<string>() { "Vegetable", "Fruit" } ;
        }

        public override IReadOnlyList<string> Foods 
        { get; protected set; }

        public override string Sound()
        {
            return $"Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, " +
                $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
