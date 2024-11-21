using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double SummerFuelConsumptionPerKm = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionInLitersPerKm) 
            : base(fuelQuantity, fuelConsumptionInLitersPerKm)
        {
            base.FuelConsumptionInLitersPerKm += SummerFuelConsumptionPerKm;
        }

        public override void Refueling(double fuelQuantity)
        {
            base.FuelQuantity += fuelQuantity * 0.95;
        }
    }
}
