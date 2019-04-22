using AutoMapper;
using Supermarket.Domain.Models;
using Supermarket.Extensions;
using Supermarket.Ressource.CategoryRessources.Read;
using Supermarket.Ressource.ProductResources.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Mapping
{
    public class ModelToRessoureProfile:Profile
    {
        public ModelToRessoureProfile()
        {
            CreateMap<Category, CategoryOutputResource>();
            CreateMap<Product, ProductOutputResource>()
                .ForMember(src => src.UnitOfMeasurement,
                            opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}
