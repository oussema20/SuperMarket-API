using Supermarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Domain.Services.Communication.ProductsCommunications
{
    public class ProductResponceFormatter : BaseResponce
    {

        public Product Product { get; private set; }

        private ProductResponceFormatter(bool success, string message, Product product) : base(success, message)
        {
            Product = product;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public ProductResponceFormatter(Product product) : this(true, string.Empty, product)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProductResponceFormatter(string message) : this(false, message, null)
        { }
    }
}
