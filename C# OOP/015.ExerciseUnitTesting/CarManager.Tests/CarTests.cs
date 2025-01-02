using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelAmount;
        private double fuelCapacity;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.make = "Golf";
            this.model = "Golf 5";
            this.fuelConsumption = 5.5;
            this.fuelAmount = 0;
            this.fuelCapacity = 55;
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void ConstructorsSetsPropertyValuesCorrectly()
        {
            string expectedMake = this.car.Make;
            string expectedModel = this.car.Model;
            double expectedConsumption = this.car.FuelConsumption;
            double expectedCapacity = this.car.FuelCapacity;

            Assert.True(expectedMake == this.car.Make);
            Assert.True(expectedModel == this.car.Model);
            Assert.True(expectedConsumption == this.car.FuelConsumption);
            Assert.True(expectedCapacity == this.car.FuelCapacity);
            Assert.True(this.fuelAmount == this.car.FuelAmount);
        }

        [Test]
        public void MakePropertyCannotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(
            () => this.car = new Car("", this.model, this.fuelConsumption, this.fuelCapacity),
            "Property make is empty");

            Assert.Throws<ArgumentException>(
            () => this.car = new Car(null, this.model, this.fuelConsumption, this.fuelCapacity),
            "Property make is null");
        }

        [Test]
        public void MakePropertyShouldReturnCorrectData()
        {
            string makePropertyValue = this.car.Make;

            Assert.True(makePropertyValue == this.make);
        }

        [Test]
        public void ModelPropertyCannotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(
            () => this.car = new Car(this.make, "", this.fuelConsumption, this.fuelCapacity),
            "Property model is empty");

            Assert.Throws<ArgumentException>(
            () => this.car = new Car(this.make, null, this.fuelConsumption, this.fuelCapacity),
            "Property model is null");
        }

        [Test]
        public void ModelPropertyShouldReturnCorrectData()
        {
            string modelPropertyValue = this.car.Model;

            Assert.True(modelPropertyValue == this.model, "Property model does not return correct data");
        }

        [Test]
        public void FuelConsumptionPropertyCannotBeZeroOrNegaive()
        {
            Assert.Throws<ArgumentException>(
            () => this.car = new Car(this.make, this.model, 0, this.fuelCapacity),
            "Property fuelConsumption is zero");

            Assert.Throws<ArgumentException>(
            () => this.car = new Car(this.make, this.model, -13, this.fuelCapacity),
            "Property fuelConsumption is negative");
        }

        [Test]
        public void FuelConsumptionPropertyShouldReturnCorrectData()
        {
            double fuelConsumptionPropertyValue = this.car.FuelConsumption;

            Assert.True(fuelConsumptionPropertyValue == this.fuelConsumption,
            "Property fuelConsumption does not return correct data");
        }

        [Test]
        public void FuelAmountPropertyCannotBeNegative()
        {
            Assert.True(this.car.FuelAmount >= this.fuelAmount, "Property fuelAmount is negative");
        }


        [Test]
        public void FuelAmountPropertyShouldReturnCorrectData()
        {
            double fuelAmountPropertyValue = this.car.FuelAmount;
            Assert.True(fuelAmountPropertyValue == this.fuelAmount,
            "Property fuelAmount does not return correct data");
        }

        [Test]
        public void FuelCapacityPropertyCannotBeZeroOrNegaive()
        {
            Assert.Throws<ArgumentException>(
            () => this.car = new Car(this.make, this.model, this.fuelConsumption, 0),
            "Property fuelCapacity is zero");

            Assert.Throws<ArgumentException>(
            () => this.car = new Car(this.make, this.model, this.fuelConsumption, -12),
            "Property fuelCapacity is negative");
        }

        [Test]
        public void FuelCapacityPropertyShouldReturnCorrectData()
        {
            double fuelCapacityPropertyValue = this.car.FuelCapacity;

            Assert.True(fuelCapacityPropertyValue == this.fuelCapacity,
            "Property fuelCapacity does not return correct data");
        }

        [Test]
        public void RefuelMethodRefuelCar()
        {
            double fuel = 21;
            this.car.Refuel(fuel);
            Assert.True(this.car.FuelAmount == fuel, "The Refuel method not working properly");

            this.car.Refuel(fuel);
            Assert.True(this.car.FuelAmount == fuel + fuel, "The Refuel method not working properly");

            this.car.Refuel(fuel);
            Assert.True(this.car.FuelAmount == this.car.FuelCapacity, 
            "The amount of fuel is more than the fuel capacity");
        }

        [Test]
        public void RefuelMethodCannotAcceptZeroOrNegativeFuel()
        {
            double zeroFuel = 0;
            double negativeFuel = -4;

            Assert.Throws<ArgumentException>(
            () => this.car.Refuel(zeroFuel),
            "Refuel method accept zero fuel");

            Assert.Throws<ArgumentException>(
            () => this.car.Refuel(negativeFuel),
            "Refuel method accept negative fuel");
        }

        [Test]
        public void DriveMethodShouldReduceFuel()
        {
            double fuel = 100;
            this.car.Refuel(fuel);

            double distance = 75;

            double expectedFuelAmount = this.car.FuelAmount - 4.125;

            this.car.Drive(distance);

            Assert.True(this.car.FuelAmount == expectedFuelAmount, "Drive method does not reduce fuel properly");
        }

        [Test]
        public void DriveMethodThrowsAnErrorWhenIsNotEnoughFuel()
        {
            double fuel = 100;
            this.car.Refuel(fuel);

            double distance = 10000;
            Assert.Throws<InvalidOperationException>(
            () => this.car.Drive(distance), 
            "Drive method does not throws an error when there is not enough fuel");
        }
    }
}