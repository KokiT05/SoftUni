using _020.Workshop.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop
{
    public class Engine
    {
        private ILogger logger;

        public Engine(ILogger logger)
        {
            this.logger = logger;
        }

        public void Start()
        {
            logger.Log("Game Started");
        }

        public void End()
        {
            logger.Log("Game Ended");
        }
    }
}
