﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public class Tea : Drink
    {
        //Code from lecture
        public Tea(string name, int portion, string brand) : base(name, portion, 2.50m, brand)
        {

        }

            //My code
            //private const decimal TeaPrice = 2.50M;
            //public Tea(string name, int portion, string brand) 
            //    : base(name, portion, TeaPrice, brand)
            //{
            //}
    }
}
