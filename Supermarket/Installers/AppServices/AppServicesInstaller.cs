using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Controllers.Services;
using Supermarket.Domain.Repositories;
using Supermarket.Domain.Services;
using Supermarket.Persistence.Contexts;
using Supermarket.Persistence.Repositories;

namespace Supermarket.Installers.AppServices
{
    public class AppServicesInstaller: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
