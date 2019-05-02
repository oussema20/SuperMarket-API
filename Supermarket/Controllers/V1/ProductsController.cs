using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Domain.Models;
using Supermarket.Domain.Services.ProductServices;
using Supermarket.Extensions;
using Supermarket.Ressource.ProductResources.Read;
using Supermarket.Ressource.ProductResources.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Controllers.V1
{


    public class ProductsController : ODataController
    {
        private IProductService _productService;
        private IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [EnableQuery]
        public async Task<IEnumerable<ProductOutputResource>> Get()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductOutputResource>>(products);
            return resources;
        }

        public async Task<IActionResult> Post([FromBody] ProductInputResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<ProductInputResource, Product>(resource);

            var result = await _productService.SaveAsync(product);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Product, ProductOutputResource>(result.Product);

            return Ok(productResource);
        }


        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] ProductInputResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<ProductInputResource, Product>(resource);
            var result = await _productService.UpdateAsync(key, product);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var productResource = _mapper.Map<Product, ProductOutputResource>(result.Product);

            return Ok(productResource);

        }

        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            var result = await _productService.DeleteAsync(key);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Product, ProductOutputResource>(result.Product);

            return Ok(productResource);
        }

    }
}
