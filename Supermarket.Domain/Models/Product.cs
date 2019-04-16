using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Domain.Models
{
    public class Product
    {
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
