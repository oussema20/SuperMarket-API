using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
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

    [ODataRoutePrefix("Categories")]
    public class CategoriesController : ODataController
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;


        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
      //  [EnableQuery]
        [Produces("application/json")]
        [EnableQuery]
        public async Task<IEnumerable<CategoryOutputResource>> Get()
        {
            var categories = await _categoryService.ListAsync();
            var ressources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryOutputResource>>(categories);
            return ressources;
        }
        [EnableQuery]
        public async Task<IActionResult> Post([FromBody] CategoryInputResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
                

            var category = _mapper.Map<CategoryInputResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
                

            var categoryResource = _mapper.Map<Category, CategoryOutputResource>(result.Category);
            return Ok(categoryResource);
        }

        public async Task<IActionResult>Put([FromODataUri] int key, [FromBody] CategoryInputResource ressource){
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<CategoryInputResource, Category>(ressource);
            var result = await _categoryService.UpdateAsync(key, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryOutputResource>(result.Category);
            return Ok(categoryResource);
        }


        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            var result = await _categoryService.DeleteAsync(key);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryOutputResource>(result.Category);
            return Ok(categoryResource);
        }
    }
}
