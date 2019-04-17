using Supermarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Domain.Services.Communication.CategoriesCommunications
{
    public class SaveCategoryResponce: BaseResponce
    {
        public Category Category { get; private set; }
        private SaveCategoryResponce(bool success, string message, Category category):base(success,message)
        {
            Category = category;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveCategoryResponce(Category category) : this(true, string.Empty, category)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveCategoryResponce(string message) : this(false, message, null)
        { }
    }
}
