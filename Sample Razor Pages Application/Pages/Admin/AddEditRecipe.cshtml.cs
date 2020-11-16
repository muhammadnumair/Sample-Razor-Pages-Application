using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sample_Razor_Pages_Application.Models;

namespace Sample_Razor_Pages_Application.Pages.Admin
{
    [Authorize]
    public class AddEditRecipeModel : PageModel
    {
        private IRecipesService recipesService;

        [FromRoute]
        public long? id { get; set; }

        public bool isNewRecipe { 
            get { return id == null; } 
        }

        [BindProperty]
        public Models.Recipe recipe { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }
        public AddEditRecipeModel(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }
        public async Task OnGetAsync()
        {
            recipe = await recipesService.FindAsync(id.GetValueOrDefault()) ?? new Recipe();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            recipe.Id = id.GetValueOrDefault();
            var updatedRecipe = await recipesService.FindAsync(id.GetValueOrDefault()) ?? new Recipe();
            updatedRecipe.Id = recipe.Id;
            updatedRecipe.Name = recipe.Name;
            updatedRecipe.Description = recipe.Description;
            updatedRecipe.Ingredients = recipe.Ingredients;
            updatedRecipe.Directions = recipe.Directions;

            if(Image != null)
            {
                using ( var stream = new System.IO.MemoryStream())
                {
                    await Image.CopyToAsync(stream);
                    updatedRecipe.Image = stream.ToArray();
                    updatedRecipe.ImageContentType = Image.ContentType;
                }
            }

            await recipesService.SaveAsync(updatedRecipe);
            return RedirectToPage("/Recipe", new { id = recipe.Id });
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await recipesService.DeleteAsync(id.Value);
            return RedirectToPage("/Index");
        }
    }
}
