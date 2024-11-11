using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private const int minRange = 0;
        private const int maxRange = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace
                    (value, GlobalConstants.InvalidNameExceptionMessage);
                //if (string.IsNullOrEmpty(value))
                //{
                //    throw new ArgumentException("A name should not be empty.");
                //}

                this.name = value;
            }
        }
        public int Endurance
        {
            get
            {
                return this.endurance;
            }

            private set
            {
                Validator.ThrowIfNumberIsNotInRange
                    (value, minRange, maxRange, $"{nameof(this.Endurance)} should be between 0 and 100.");
                //if (value < 0 || value > 100)
                //{
                //    throw new ArgumentException($"Endurance should be between 0 and 100.");
                //}

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return this.sprint;
            }

            private set
            {
                Validator.ThrowIfNumberIsNotInRange
                (value, minRange, maxRange, $"{nameof(this.Sprint)} should be between 0 and 100.");
                //if (value < 0 || value > 100)
                //{
                //    throw new ArgumentException($"Sprint should be between 0 and 100.");
                //}

                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }

            private set
            {
                Validator.ThrowIfNumberIsNotInRange
                    (value, minRange, maxRange, $"{nameof(this.Dribble)} should be between 0 and 100.");
                //if (value < 0 || value > 100)
                //{
                //    throw new ArgumentException($"Dribble should be between 0 and 100.");
                //}

                this.dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }

            private set
            {
                Validator.ThrowIfNumberIsNotInRange
                (value, minRange, maxRange, $"{nameof(this.Passing)} should be between 0 and 100.");
                //if (value < 0 || value > 100)
                //{
                //    throw new ArgumentException($"Passing should be between 0 and 100.");
                //}

                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }

            private set
            {
                Validator.ThrowIfNumberIsNotInRange
                    (value, minRange, maxRange, $"{nameof(this.Shooting)} should be between 0 and 100.");
                //if (value < 0 || value > 100)
                //{
                //    throw new ArgumentException($"Shooting should be between 0 and 100.");
                //}

                this.shooting = value;
            }
        }
        public double SkillLevel => CalculateSkillLevel();

        private double CalculateSkillLevel()
        {
            double skillLevel = Math.Round((this.Endurance +
                            this.Sprint +
                            this.Dribble +
                            this.Passing +
                            this.Shooting) / 5.0);
            return skillLevel;
        }
    }
}
