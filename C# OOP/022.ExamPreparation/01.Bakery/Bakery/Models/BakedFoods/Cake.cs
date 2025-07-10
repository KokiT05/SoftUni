using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public class Cake : BakedFood
    {
        // Code from the lecture

        public Cake(string name, decimal price) : base(name, 245, price)
        {
            
        }

        // My code
        //private const int InitialCakePortion = 245;
        //public Cake(string name, decimal price) 
        //    : base(name, InitialCakePortion, price)
        //{
        //}
    }
}
