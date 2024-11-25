using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string livingRegion, string Breed) 
            : base(name, weight, foodEaten, livingRegion, Breed)
        {
            this.Foods = new List<string>() { "Vegetable", "Meat" };
        }

        public override IReadOnlyList<string> Foods { get; protected set; }

        public override string Sound()
        {
            return $"Meow";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, " +
                $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
