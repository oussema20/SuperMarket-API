using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Controllers.Services.CategoryServicesImplementations;
using Supermarket.Controllers.Services.ProductServicesImplementations;
using Supermarket.Domain.Repositories;
using Supermarket.Domain.Repositories.CategoryRepositories;
using Supermarket.Domain.Repositories.ProductRepositories;
using Supermarket.Domain.Services.CategoryServices;
using Supermarket.Domain.Services.ProductServices;
using Supermarket.Persistence.Contexts;
using Supermarket.Persistence.Repositories;
using Supermarket.Persistence.Repositories.CategoryRepositoriesImplementations;
using Supermarket.Persistence.Repositories.ProductRepositoriesImplementations;

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
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
