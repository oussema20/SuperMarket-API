using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Models;
using Supermarket.Domain.Repositories.ProductRepositories;
using Supermarket.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Persistence.Repositories.ProductRepositoriesImplementations
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context)
        {

        }

        public async Task AddAsync(Product product)
        {
           await _context.Products.AddAsync(product);
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Category)
                                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
