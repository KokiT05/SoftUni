using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string Breed) 
            : base(name, weight, foodEaten, livingRegion, Breed)
        {
            this.Foods = new List<string>() { "Meat" };
        }

        public override IReadOnlyList<string> Foods { get; protected set; }

        public override string Sound()
        {
            return $"ROAR!!!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, " +
                $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
