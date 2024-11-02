using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DefaultGrams = 250;
        private const double DefaultCalories = 1000;
        private const decimal DefaultPrice = 5;
        public Cake(string name) 
            : base(name, DefaultPrice, DefaultGrams, DefaultCalories)
        {
            //this.Price = 5;
            //this.Grams = 250;
            //this.Calories = 1000;
        }
    }
}
