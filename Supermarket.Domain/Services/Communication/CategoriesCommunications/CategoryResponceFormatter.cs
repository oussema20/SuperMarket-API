﻿using Supermarket.Domain.Models;

namespace Supermarket.Domain.Services.Communication.CategoriesCommunications
{
    public class CategoryResponceFormatter: BaseResponce
    {
        public Category Category { get; private set; }
        private CategoryResponceFormatter(bool success, string message, Category category):base(success,message)
        {
            Category = category;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public CategoryResponceFormatter(Category category) : this(true, string.Empty, category)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CategoryResponceFormatter(string message) : this(false, message, null)
        { }
    }
}
