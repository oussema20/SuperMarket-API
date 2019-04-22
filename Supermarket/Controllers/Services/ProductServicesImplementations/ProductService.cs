using Supermarket.Domain.Models;
using Supermarket.Domain.Repositories;
using Supermarket.Domain.Repositories.CategoryRepositories;
using Supermarket.Domain.Repositories.ProductRepositories;
using Supermarket.Domain.Services.Communication.ProductsCommunications;
using Supermarket.Domain.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Controllers.Services.ProductServicesImplementations
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResponceFormatter> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new ProductResponceFormatter("Product was not found");

            try
            {
                 _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponceFormatter(existingProduct);
            }
            catch(Exception ex)
            {
                return new ProductResponceFormatter($"An Error occured when deleting product : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<ProductResponceFormatter> SaveAsync(Product product)
        {
            try
            {
                var existingCategory = await _categoryRepository.FindByIdAsync(product.CategoryId);

                if (existingCategory == null)
                    return new ProductResponceFormatter("Invalid Category Id");

                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();

                return new ProductResponceFormatter(product);
            }
            catch(Exception ex)
            {
                return new ProductResponceFormatter($"An Error occured when saving the product : {ex.Message}");
            }


        }

        public async Task<ProductResponceFormatter> UpdateAsync(int id, Product product)
        {
            //check wether the product exists or not
            var existingProduct = await _productRepository.FindByIdAsync(id);
            // if not found return that the product to update was not found
            if (existingProduct == null)
                return new ProductResponceFormatter("Product not found");

            //if it exists do the needed updates
            existingProduct.Name = product.Name;
            existingProduct.UnitOfMeasurement = product.UnitOfMeasurement;
            existingProduct.QuantityInPackage = product.QuantityInPackage;
            existingProduct.CategoryId = product.CategoryId;

            //now go to saving the changes 
            try
            {
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponceFormatter(existingProduct);
            }catch(Exception ex)
            {
                return new ProductResponceFormatter($"An error occurred when updating the product: {ex.Message}");
            }
        }
    }
}
