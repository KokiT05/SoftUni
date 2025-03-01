using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;
        private bool canParticipate;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                this.name = value;
            }
        }

        public ICar Car 
        { 
            get { return this.car; } 
            private set { 
                //if (this.car == null)
                //{
                //    throw new ArgumentException(string.Format(ExceptionMessages.CarInvalid));
                //}

                this.car = value; 
            } 
        }

        public int NumberOfWins { get { return this.numberOfWins; } private set { this.numberOfWins = value; } }

        public bool CanParticipate => this.Car != null;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.CarInvalid));
            }

            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins += 1;
        }
    }
}
