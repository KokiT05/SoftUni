using NUnit.Framework;
using System;
using System.Diagnostics;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        UnitCar car;
        UnitDriver driver;
        RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.car = new UnitCar("Golf 5", 110, 1900.0);
            this.driver = new UnitDriver("Ivan", this.car);
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void AddDriver_WhenDriverIsNull_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));

            Exception exception = Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));

            Assert.That(exception.Message.Equals("Driver cannot be null."));
        }

        [Test]
        public void AddDriver_WhenDriverIsAlreadyAdded_ShouldThrowInvalidOperationException()
        {
            this.raceEntry.AddDriver(this.driver);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(this.driver));

            Exception exception = Assert.Throws<InvalidOperationException>(() => 
                                raceEntry.AddDriver(this.driver));

            Assert.That(exception.Message.Equals($"Driver {this.driver.Name} is already added."));
        }

        [Test]
        public void AddDriverMethod_ShouldAddDriver()
        {
            string result = this.raceEntry.AddDriver(this.driver);

            Assert.That(result.Equals($"Driver {this.driver.Name} added in race."));

            Assert.That(this.raceEntry.Counter, Is.EqualTo(1));

            UnitDriver newDriver = new UnitDriver("Anton", this.car);

            result = this.raceEntry.AddDriver(newDriver);

            Assert.That(result.Equals($"Driver {newDriver.Name} added in race."));

            Assert.That(this.raceEntry.Counter, Is.EqualTo(2));
        }

        [Test]
        public void CalculateAverageHorsePowerMethod_ShouldTrowsInvalidOperationException()
        {
            this.raceEntry.AddDriver(this.driver);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());

            Exception exception = Assert.Throws<InvalidOperationException>
                                (() => this.raceEntry.CalculateAverageHorsePower());

            Assert.That(exception.Message.Equals($"The race cannot start with less than {2} participants."));
        }

        [Test]
        public void CalculateAverageHorsePowerMethod_ShouldReturnEverageHorsePower()
        {
            UnitCar firstCar = new UnitCar("Golf 4", 100, 1900.0);
            UnitDriver firstDrive = new UnitDriver("FirstDriver", firstCar);

            UnitCar secondCar = new UnitCar("Golf 7", 200, 2000.0);
            UnitDriver secondDriver = new UnitDriver("SecondDriver", secondCar);

            this.raceEntry.AddDriver(firstDrive);
            this.raceEntry.AddDriver(secondDriver);

            double expectedResult = 150;
            double result = this.raceEntry.CalculateAverageHorsePower();

            Assert.That(expectedResult, Is.EqualTo(result));
        }
    }
}