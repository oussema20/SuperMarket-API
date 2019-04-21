using AutoMapper;
using Supermarket.Domain.Models;
using Supermarket.Ressource.CategoryRessources.Write;
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
            CreateMap<CategoryResponce, Category>();
        }
    }
}
