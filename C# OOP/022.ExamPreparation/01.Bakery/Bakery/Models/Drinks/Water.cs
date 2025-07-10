using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public class Water : Drink
    {
        //Code from the lecture
        public Water(string name, int portion, string brand) : base(name, portion, 1.50m,brand)
        {
            
        }

        //My code
        //private const decimal WaterPrice = 1.50M;
        //public Water(string name, int portion, string brand) 
        //    : base(name, portion, WaterPrice, brand)
        //{
        //}
    }
}
