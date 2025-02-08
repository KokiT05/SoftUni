using MicrosoftDepencyInjectionExample.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDepencyInjectionExample
{
    public class GameMovement : IGameMovement
    {
        private ILogger logger;
        public GameMovement(ILogger logger)
        {
            this.logger = logger;
        }

        public void Move()
        {
            logger.Log("Game moved!!!");
        }
    }
}
