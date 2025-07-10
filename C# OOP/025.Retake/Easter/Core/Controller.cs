using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {

            IBunny bunny = null;

            if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            this.bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);

            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IBunny bunny = this.bunnies.Models
                                        .Where(e => e.Energy >= 50 && e.Dyes.Any(d => d.IsFinished() == false))
                                        .OrderByDescending(b => b.Energy)
                                        .FirstOrDefault();

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IEgg egg = this.eggs.FindByName(eggName);

            IWorkshop workshop = new Workshop();
            workshop.Color(egg, bunny);

            if (bunny.Energy == 0)
            {
                this.bunnies.Remove(bunny);
            }

            if (egg.IsDone())
            {
                // TODO!
                return string.Format(OutputMessages.EggIsDone, egg.Name);
            }
            else
            {
                return string.Format(OutputMessages.EggIsNotDone, egg.Name);
            }

        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            int coloredEgg = this.eggs.Models.Select(e => e).Where(e => e.IsDone() == true).Count();
            result.AppendLine($"{coloredEgg} eggs are done!");

            result.AppendLine("Bunnies info:");

            foreach (IBunny bunny in this.bunnies.Models)
            {
                int countOfNotFinishedDyes = bunny.Dyes.Where(d => d.IsFinished() == false).Count();

                result.AppendLine($"Name: {bunny.Name}");
                result.AppendLine($"Energy: {bunny.Energy}");
                result.AppendLine($"Dyes: {countOfNotFinishedDyes} not finished");
            }

            return result.ToString().TrimEnd();
        }
    }
}
