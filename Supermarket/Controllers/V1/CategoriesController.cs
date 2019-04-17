using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Domain.Models;
using Supermarket.Domain.Services.CategoryServices;
using Supermarket.Extensions;
using Supermarket.Ressource.CategoryRessources.Read;
using Supermarket.Ressource.CategoryRessources.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiController]

    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<CategoryRessource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var ressources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryRessource>>(categories);
            return ressources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryRessource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryRessource, Category>(resource);
        }
    }
}
