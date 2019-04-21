using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Ressource.CategoryRessources.Write
{
    public class CategoryResponce
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
