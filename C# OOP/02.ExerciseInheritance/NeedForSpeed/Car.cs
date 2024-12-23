﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            //this.DefaultFuelConsumption = 3;
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
