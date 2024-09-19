using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RawData
{
    public class Engine
    {
        private int power;
        private string speed;

        public Engine(int power, int speed)
        {
            this.Power = power;
            this.Speed = speed;
        }

        public int Power { get; set; }
        public int Speed { get; set; }
    }
}
