using _020.Workshop.Contracts;
using _020.Workshop.DI;
using _020.Workshop.DI.Containers;
using _020.Workshop.ILoggers;

namespace _020.Workshop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new SnakeGameContainer();
            container.ConfigureServices();



            //ILogger logger = new ConsoleLogger();
            Injector injector = new Injector(container);
            Engine engine = InjectorSingleton.Instance.Inject<Engine>();
            engine.Start();
            engine.End();
        }
    }
}
