using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
            
        }
        public void Color(IEgg egg, IBunny bunny)
        {
            bool isntFinishedDye = bunny.Dyes.Any(d => d.IsFinished() == false);

            if (bunny.Energy > 0 && isntFinishedDye)
            {
                IDye dye = bunny.Dyes.FirstOrDefault(d => d.IsFinished() == false);

                while (egg.IsDone() == false && (bunny.Energy > 0 && isntFinishedDye))
                {
                    bunny.Work();
                    dye.Use();
                    egg.GetColored();

                    if (dye.IsFinished())
                    {
                        dye = bunny.Dyes.FirstOrDefault(d => d.IsFinished() == false);
                    }

                    isntFinishedDye = bunny.Dyes.Any(d => d.IsFinished() == false);
                }
            }
        }
    }
}
