using Supermarket.Ressource.CategoryRessources.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Ressource.ProductResources.Read
{
    public class ProductOutputResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
        public CategoryOutputResource Category { get; set; }
    }
}
