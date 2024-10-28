using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRace
{
    public class Race
    {
        private List<Racer> contestants;
        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.contestants = new List<Racer>(this.Capacity);
            //this.Contestants = new List<Racer>(this.Capacity);
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return contestants.Count; } }

        public void Add(Racer racer)
        {
            if (Capacity > contestants.Count)
            {
                contestants.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            if (contestants.Any(n => n.Name == name))
            {
                Racer racer = contestants.FirstOrDefault(n => n.Name == name);
                contestants.Remove(racer);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            Racer racer = contestants.OrderByDescending(a => a.Age).FirstOrDefault();
            return racer;
        }

        public Racer GetRacer(string name)
        {
            Racer racer = contestants.FirstOrDefault(n => n.Name == name);
            return racer;
        }

        public Racer GetFastestRacer()
        {
            Racer racer = contestants.OrderByDescending(s => s.Car.Speed).FirstOrDefault();
            return racer;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Racers participating at {this.Name}:");
            foreach (Racer racer in contestants)
            {
                stringBuilder.AppendLine(racer.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //public List<Racer> Contestants { get; set; }
    }
}
