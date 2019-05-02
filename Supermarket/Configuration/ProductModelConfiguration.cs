using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Configuration
{
    public class ProductModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            var product = builder.EntitySet<Product>("Products").EntityType;
        }
    }
}
