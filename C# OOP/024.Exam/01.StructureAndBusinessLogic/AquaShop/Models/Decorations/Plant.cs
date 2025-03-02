using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int ComfortDefaultValue = 5;
        private const decimal PriceDefaultValue = 10;

        public Plant() : base(ComfortDefaultValue, PriceDefaultValue)
        {
        }
    }
}
