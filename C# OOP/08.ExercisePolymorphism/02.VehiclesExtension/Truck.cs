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
        private const double TankCapacityHole = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, SummerFuelConsumptionPerKm)
        {
        }

        public virtual void Refueling(double fuelQuantity)
        {
            if (fuelQuantity <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuelQuantity > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuelQuantity} fuel in the tank");
            }

            this.FuelQuantity += (fuelQuantity * 0.95);
        }
    }
}
