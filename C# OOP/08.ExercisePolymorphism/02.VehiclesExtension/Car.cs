using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    internal class Car : Vehicle
    {
        private const double SummerFuelConsumptionPerKm = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, SummerFuelConsumptionPerKm)
        {
        }
    }
}
