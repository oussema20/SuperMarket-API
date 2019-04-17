using Supermarket.Domain.Models;
using Supermarket.Domain.Repositories.CategoryRepositories;
using Supermarket.Domain.Services.CategoryServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Controllers.Services.CategoryServicesImplementations
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }
    }
}
