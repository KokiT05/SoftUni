﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RawData
{
    public class Tire
    {
        private int age;
        private double pressure;

        public Tire(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        public int Age { get; set; }
        public double Pressure { get; set; }
    }
}
