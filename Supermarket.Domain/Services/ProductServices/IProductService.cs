using Supermarket.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.Domain.Services.Communication.ProductsCommunications;

namespace Supermarket.Domain.Services.ProductServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<ProductResponceFormatter> SaveAsync(Product product);
        Task<ProductResponceFormatter> UpdateAsync(int id, Product product);
        Task<ProductResponceFormatter> DeleteAsync(int id);
    }
}
