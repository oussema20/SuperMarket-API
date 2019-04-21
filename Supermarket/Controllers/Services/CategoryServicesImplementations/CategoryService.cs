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
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<SaveCategoryResponce> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponce(category);
            }
            catch(Exception ex)
            {
                return new SaveCategoryResponce($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<SaveCategoryResponce> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new SaveCategoryResponce("Category not found");

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponce(existingCategory);
            }
            catch (Exception e)
            {
                return new SaveCategoryResponce($"An error occured when updating the category:{e.Message}");
            }
        }
    }
}
