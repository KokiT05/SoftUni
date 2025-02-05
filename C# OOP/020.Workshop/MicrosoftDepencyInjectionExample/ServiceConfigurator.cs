
using Microsoft.Extensions.DependencyInjection;
using MicrosoftDepencyInjectionExample.Contracts;
using MicrosoftDepencyInjectionExample.ILoggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDepencyInjectionExample
{
    public class ServiceConfigurator
    {
        public static ServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<ILogger, FileLogger>
                (f => new FileLogger("../../../logstest.txt"));

            //serviceCollection.AddTransient<ILogger, ConsoleLogger>();

            serviceCollection.AddTransient<Engine, Engine>();

            serviceCollection.AddTransient<IGameMovement, GameMovement>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
