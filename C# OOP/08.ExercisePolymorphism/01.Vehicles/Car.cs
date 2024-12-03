using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    internal class Car : Vehicle
    {
        private const double SummerFuelConsumptionPerKm = 0.9;
        public Car(double fuelQuantity, double fuelConsumptionInLitersPerKm) 
            : base(fuelQuantity, fuelConsumptionInLitersPerKm, SummerFuelConsumptionPerKm)
        {
        }
    }
}
