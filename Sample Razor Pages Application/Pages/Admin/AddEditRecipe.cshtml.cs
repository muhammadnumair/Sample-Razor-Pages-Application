using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sample_Razor_Pages_Application.Pages.Admin
{
    public class AddEditRecipeModel : PageModel
    {
        [FromRoute]
        public long? id { get; set; }

        public bool isNewRecipe { 
            get { return id == null; } 
        }

        public Models.Recipe recipe { get; set; }
        public void OnGet()
        {
        }
    }
}
