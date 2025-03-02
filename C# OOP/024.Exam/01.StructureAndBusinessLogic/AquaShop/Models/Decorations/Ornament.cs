using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int ComfortDefaultValue = 1;
        private const decimal PriceDefaultValue = 5;
        public Ornament() : base(ComfortDefaultValue, PriceDefaultValue)
        {
        }
    }
}
