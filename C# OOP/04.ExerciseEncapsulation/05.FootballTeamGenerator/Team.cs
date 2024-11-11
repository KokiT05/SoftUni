using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;
        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public int NumberOfPlayers => this.players.Count;

        public IReadOnlyList<Player> Players
        {
            get { return this.players.AsReadOnly(); }
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
        public double Rating => this.TotalRating();

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!this.players.Any(n => n.Name == playerName))
            {
                throw new ArgumentException
                    ($"Player {playerName} is not in {this.Name} team.");
            }

            Player player = this.players.FirstOrDefault(n => n.Name == playerName);
            this.players.Remove(player);
        }

        private double TotalRating()
        {
            if (players.Count == 0)
            {
                return 0;
            }

            double totalRating = players.Average(p => p.SkillLevel);
            //foreach (Player player in this.Players)
            //{
            //    totalRating += player.SkillLevel;
            //}

            return totalRating;
        }
    }
}
