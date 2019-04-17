using AutoMapper;
using Supermarket.Domain.Models;
using Supermarket.Ressource;
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
            CreateMap<Category, CategoryRessource>();
        }
    }
}
