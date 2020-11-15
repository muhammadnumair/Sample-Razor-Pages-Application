using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sample_Razor_Pages_Application.Models;

namespace Sample_Razor_Pages_Application.Pages.Admin
{
    public class AddEditRecipeModel : PageModel
    {
        private IRecipesService recipesService;

        [FromRoute]
        public long? id { get; set; }

        public bool isNewRecipe { 
            get { return id == null; } 
        }

        public Models.Recipe recipe { get; set; }

        public AddEditRecipeModel(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }
        public void OnGet()
        {
            recipe = recipesService.Find(id.GetValueOrDefault()) ?? new Recipe();
        }
    }
}
