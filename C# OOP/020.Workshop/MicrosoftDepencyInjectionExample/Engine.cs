using MicrosoftDepencyInjectionExample.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDepencyInjectionExample
{
    public class Engine
    {
        private ILogger logger;
        private IGameMovement gameMovement;

        public Engine(ILogger logger, IGameMovement gameMovement)
        {
            this.logger = logger;
            this.gameMovement = gameMovement;
        }

        public void Start()
        {
            logger.Log("Game Started");
            this.gameMovement.Move();
        }

        public void End()
        {
            logger.Log("Game Ended");
        }
    }
}
