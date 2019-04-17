using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Domain.Models;
using Supermarket.Domain.Services;
using Supermarket.Ressource;
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
    }
}
