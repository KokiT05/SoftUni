using _020.Workshop.Contracts;
using _020.Workshop.ILoggers;

namespace _020.Workshop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();

            Engine engine = new Engine(logger);
            engine.Start();
            engine.End();
        }
    }
}
