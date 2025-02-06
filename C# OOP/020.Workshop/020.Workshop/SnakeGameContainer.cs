using _020.Workshop.Contracts;
using _020.Workshop.DI.Containers;
using _020.Workshop.Drawers;
using _020.Workshop.GameObjects;
using _020.Workshop.ILoggers;
using _020.Workshop.Movers;
using _020.Workshop.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop
{
    public class SnakeGameContainer : AbstractContainer
    {
        public override void ConfigureServices()
        {
            CreateMapping<ILogger, FileLogger>(() => new FileLogger("../../../logs.txt"));
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IDrawer, ConsoleDrawer>();
            CreateMapping<IMover, FastMover>();
            //CreateMapping<IGameObject, Ball>();
        }
    }
}
