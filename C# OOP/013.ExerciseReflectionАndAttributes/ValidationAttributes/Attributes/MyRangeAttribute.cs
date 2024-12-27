using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        private readonly bool inclusive;

        public MyRangeAttribute(int minValue, int maxValue, bool inclusive = true)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.inclusive = inclusive;
        }
        public override bool IsValid(object @object)
        {
            int number = (int)@object;

            if (this.inclusive)
            {
                return number >= this.minValue && number <= this.maxValue;
            }

            return number > this.minValue && number < this.maxValue;
        }
    }
}
