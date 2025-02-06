using _020.Workshop.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop
{
    public class InjectorSingleton
    {
        private static Injector instance;

        public static Injector Instance
        {
            get
            {
                if (instance == null)
                {
                    SnakeGameContainer container = new SnakeGameContainer();
                    container.ConfigureServices();
                    instance = new Injector(container);
                }

                return instance;
            }
        }
    }
}
