using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private int comfort;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();


            this.Name = name;
            this.Capacity = capacity;


        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity;}
            private set { this.capacity = value; }
        }

        public int Comfort
        {
            get { return this.Decorations.Sum(d => d.Comfort); }
        }

        public ICollection<IDecoration> Decorations { get; private set; }

        public ICollection<IFish> Fish { get; private set; }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity <= this.Fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (IFish fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            if (this.Fish.Count == 0)
            {
                return "none";
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{this.Name} ({this.GetType().Name}):");
            stringBuilder.Append("Fish: ");
            foreach (IFish fish in this.Fish)
            {
                stringBuilder.Append($"{fish.Name} ");
            }

            stringBuilder.ToString().TrimEnd();

            stringBuilder.AppendLine($"Decorations: {this.Decorations.Count}");
            stringBuilder.AppendLine($"Comfort: {this.Comfort}");

            return stringBuilder.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }
    }
}
