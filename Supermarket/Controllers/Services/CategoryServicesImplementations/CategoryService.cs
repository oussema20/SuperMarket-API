using Supermarket.Domain.Models;
using Supermarket.Domain.Repositories;
using Supermarket.Domain.Repositories.CategoryRepositories;
using Supermarket.Domain.Services.CategoryServices;
using Supermarket.Domain.Services.Communication.CategoriesCommunications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Controllers.Services.CategoryServicesImplementations
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponceFormatter> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new CategoryResponceFormatter("Category not found");

            try{
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponceFormatter(existingCategory);
            }catch(Exception ex)
            {
                return new CategoryResponceFormatter($"An error occured when deleting the category : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<CategoryResponceFormatter> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponceFormatter(category);
            }
            catch(Exception ex)
            {
                return new CategoryResponceFormatter($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponceFormatter> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new CategoryResponceFormatter("Category not found");

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponceFormatter(existingCategory);
            }
            catch (Exception e)
            {
                return new CategoryResponceFormatter($"An error occured when updating the category:{e.Message}");
            }
        }
    }
}
