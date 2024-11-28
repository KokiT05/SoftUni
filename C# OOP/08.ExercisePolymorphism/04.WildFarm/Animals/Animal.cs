using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.WildFarm.Foods;

namespace _04.WildFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, HashSet<string> allowedFoods, double weightModifier)
        {
            Name = name;
            Weight = weight;
            AllowedFoods = allowedFoods;
            WeightModifier = weightModifier;
        }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public HashSet<string> AllowedFoods { get; private set; }
        public double WeightModifier { get; private set; }
        public abstract string Sound();

        public void Eat(Food food)
        {
            string foodName = food.GetType().Name;
            if (!AllowedFoods.Contains(foodName))
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {foodName}!");
            }

            FoodEaten += food.Quantity;

            Weight += WeightModifier * food.Quantity;
        }
    }
}
