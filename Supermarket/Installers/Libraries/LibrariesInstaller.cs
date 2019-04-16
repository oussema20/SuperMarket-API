using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using SwashbuckleAspNetVersioningShim;

namespace Supermarket.Installers.Libraries
{
    public class LibrariesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvcCore().AddVersionedApiExplorer();
            services.AddApiVersioning();

            services.AddSwaggerGen(c => {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                c.ConfigureSwaggerVersions(provider);
            });
        }
    }
}
