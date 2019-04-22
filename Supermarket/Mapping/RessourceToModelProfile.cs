using AutoMapper;
using Supermarket.Domain.Models;
using Supermarket.Ressource.CategoryRessources.Write;
using Supermarket.Ressource.ProductResources.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Mapping
{
    public class RessourceToModelProfile: Profile
    {
        public RessourceToModelProfile()
        {
            CreateMap<CategoryInputResource, Category>();
            CreateMap<ProductInputResource, Product>()
                .ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => (EUnitOfMeasurement)src.UnitOfMeasurement));
        }
    }
}
