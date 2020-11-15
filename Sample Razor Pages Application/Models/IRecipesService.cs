using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Razor_Pages_Application.Models
{
    interface IRecipesService
    {
        Task<Recipe[]> GetAllAsync(int? count = null, int? page = null);
    }
}
