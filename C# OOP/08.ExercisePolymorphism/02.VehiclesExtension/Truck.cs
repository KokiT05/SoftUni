using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double SummerFuelConsumptionPerKm = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionInLitersPerKm, tankCapacity)
        {
            base.FuelConsumptionInLitersPerKm += SummerFuelConsumptionPerKm;
        }

        public override void Refueling(double fuelQuantity)
        {
            base.FuelQuantity += fuelQuantity * 0.95;
        }
    }
}
