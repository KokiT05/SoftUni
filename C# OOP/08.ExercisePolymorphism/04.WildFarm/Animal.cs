using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public virtual IReadOnlyList<string> Foods { get; protected set; }
        public abstract string Sound();

        public void AddWeight(double weight)
        {
            this.Weight += weight;
        }

        public void AddFoodEaten(int foodQuantity)
        {
            this.FoodEaten += foodQuantity;
        }
    }
}
