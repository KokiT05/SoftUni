using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name) 
            : base(name, 5, 250, 1000)
        {
            //this.Price = 5;
            //this.Grams = 250;
            //this.Calories = 1000;
        }
    }
}
