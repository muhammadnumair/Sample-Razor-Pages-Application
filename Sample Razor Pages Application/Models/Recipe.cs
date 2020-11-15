using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Razor_Pages_Application.Models
{
    public class Recipe
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Directions { get; set; }
        public string Ingredients { get; set; }
    }
}
