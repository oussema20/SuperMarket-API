using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Installers.IInstallerImplementation
{
    public static class InstallerImplementation
    {
        public static void InstallServiciesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            /**
             * 1) select all the classes that implements the IInstaller interface
               typeof(Startup).Assembly.ExportedTypes
                  .Where(x => typeof(IInstaller).IsAssignableFrom(x) ...

             * 2) make sure that they are not interfaces and not abstractions 
               && !x.IsInterface && x.IsAbstract

             * create instances of them using the activator class:
               Activator.CreateInstance

             * cast the classes as the interface
               .Cast<IInstaller>()
            **/

            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
