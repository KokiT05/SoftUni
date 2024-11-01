using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine) 
            : base(name, 3.50M, 50)
        {
            this.Caffeine = caffeine;
            //this.Milliliters = 50;
            //this.Price = 3.50M;
        }
        public double Caffeine { get; set; }
    }
}
