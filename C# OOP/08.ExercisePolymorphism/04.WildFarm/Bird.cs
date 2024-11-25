using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Bird : Animal
    {
        public Bird(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string Sound()
        {
            return string.Empty;
        }
    }
}
