using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double tankCapacit;
        private double fuelQuantity;
        private double fuelConsumption;
        protected Vehicle(double fuelQuantity,
                        double fuelConsumption,
                        double tankCapacity
                        , double airConditionerModifier)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionerModifier = airConditionerModifier;
        }

        private double AirConditionerModifier { get; set; }
        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }
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
            if (fuelQuantity <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (this.fuelQuantity + fuelQuantity > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuelQuantity} fuel in the tank");
            }

            this.FuelQuantity += fuelQuantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

        //protected Vehicle(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
        //{
        //    this.TankCapacit = tankCapacity;
        //    this.FuelConsumptionInLitersPerKm = fuelConsumptionInLitersPerKm;
        //    this.FuelQuantity = fuelQuantity;
        //    //this.
        //}

        //public double TankCapacit
        //{
        //    get { return this.tankCapacit; }
        //    protected set { this.tankCapacit = value; }
        //}

    }
}
