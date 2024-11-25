using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
            this.Foods = new List<string>() { "Meat" };
        }

        public override IReadOnlyList<string> Foods { get; protected set; }

        public override string Sound()
        {
            return $"Hoot Hoot";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
