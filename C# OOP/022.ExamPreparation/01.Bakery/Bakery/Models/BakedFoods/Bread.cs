using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public class Bread : BakedFood
    {
        //Code from the lecture

        public Bread(string name, decimal price) : base(name, 200, price)
        {
            
        }

        // My code
        //private const int InitialBreadPortion = 200;
        //public Bread(string name, decimal price) 
        //    : base(name, InitialBreadPortion, price)
        //{
        //}
    }
}
