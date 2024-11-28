﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.WildFarm.Animals;

namespace _04.WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, 
                    double weight, 
                    HashSet<string> allowedFoods, 
                    double weightModifier,
                    double wingSize) 
            : base(name, weight, allowedFoods, weightModifier)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }

    }
}
