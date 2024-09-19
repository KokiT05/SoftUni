using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, int numberOfBadges = 0)
        {
            this.Name = name;
            this.NumberOfBadges = numberOfBadges;
            this.Pokenmons = new List<Pokenmon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokenmon> Pokenmons { get; set; }

        public void AddPokemon(Pokenmon pokenmon)
        {
            Pokenmons.Add(pokenmon);
        }

        public void RemovePokemon(Pokenmon pokenmon)
        {
            Pokenmons.Remove(pokenmon);
        }
    }
}
