using Supermarket.Domain.Models;
using Supermarket.Domain.Services.Communication.CategoriesCommunications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponceFormatter> SaveAsync(Category category);
        Task<CategoryResponceFormatter> UpdateAsync(int id, Category category);
        Task<CategoryResponceFormatter> DeleteAsync(int id);
    }
}
