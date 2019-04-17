using Supermarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}
