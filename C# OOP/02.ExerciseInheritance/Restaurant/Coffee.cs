﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal DefaultPrice = 3.50M;
        private const double DefaultMilliliters = 50;
        public Coffee(string name, double caffeine) 
            : base(name, DefaultPrice, DefaultMilliliters)
        {
            this.Caffeine = caffeine;
            //this.Milliliters = 50;
            //this.Price = 3.50M;
        }
        public double Caffeine { get; set; }
    }
}
