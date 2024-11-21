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
        private double fuelConsumptionInLitersPerKm;
        protected Vehicle(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
        {
            this.TankCapacit = tankCapacity;
            this.FuelConsumptionInLitersPerKm = fuelConsumptionInLitersPerKm;
            this.FuelQuantity = fuelQuantity;
            //this.
        }

        public double TankCapacit
        {
            get { return this.tankCapacit; }
            protected set { this.tankCapacit = value; }
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }

            protected set
            {
                if (this.tankCapacit >= value)
                {
                    this.fuelQuantity = value;
                }
                else
                {
                    this.fuelQuantity = 0;
                }
            }
        }
        public double FuelConsumptionInLitersPerKm 
        { 
            get { return this.fuelConsumptionInLitersPerKm;}
            protected set { this.fuelConsumptionInLitersPerKm = value; } 
        }
        public virtual string Driving(double distance)
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
            IsEnoughFuel(fuelQuantity);

            this.FuelQuantity += fuelQuantity;
        }

        protected void IsEnoughFuel(double fuelQuantity)
        {
            if (fuelQuantity + this.FuelQuantity > this.TankCapacit)
            {
                throw new InvalidOperationException($"Cannot fit {fuelQuantity} fuel in the tank");
            }
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
