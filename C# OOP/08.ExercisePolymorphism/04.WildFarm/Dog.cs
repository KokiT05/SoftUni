using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, livingRegion)
        {
            this.Foods = new List<string>() { "Meat" };
        }

        public override IReadOnlyList<string> Foods { get; protected set; }

        public override string Sound()
        {
            return $"Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, " +
                $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
