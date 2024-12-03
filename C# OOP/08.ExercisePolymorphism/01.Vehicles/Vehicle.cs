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
        protected Vehicle(double fuelQuantity, double fuelConsumption, double airConditionerModifier)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionerModifier = airConditionerModifier;
        }

        private double AirConditionerModifier { get; set; }
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }
        public string Driving(double distance)
        {
            double requiredFuel = (this.FuelConsumption + this.AirConditionerModifier) * distance;

            if (requiredFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= requiredFuel;
            return $"{this.GetType().Name} travelled {distance} km";
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
            if ((this.FuelConsumption * distance) <= this.FuelQuantity)
            {
                return true;
            }

            return false;
        }
    }
}
