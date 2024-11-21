using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionInLitersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionInLitersPerKm = fuelConsumptionInLitersPerKm;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumptionInLitersPerKm { get; protected set; }
        public string Driving(double distance)
        {
            if (CanDrive(distance))
            {
                this.FuelQuantity -= distance * this.FuelConsumptionInLitersPerKm;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refueling(double fuelQuantity)
        {
            this.FuelQuantity += fuelQuantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

        private bool CanDrive(double distance)
        {
            if ((this.FuelConsumptionInLitersPerKm * distance) <= this.FuelQuantity)
            {
                return true;
            }

            return false;
        }
    }
}
