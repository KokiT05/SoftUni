﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Composite
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price) : base(name, price)
        {

        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{name} with the price {price}");

            return price;
        }
    }
}
