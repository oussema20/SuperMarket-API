using AutoMapper;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Supermarket.Installers.Libraries
{
    public class LibrariesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOData();
            services.AddMvc(options => {
                // disable the default asp;net core endpoint routing
                options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvcCore();

            services.AddAutoMapper();
           
        }
    }
}
