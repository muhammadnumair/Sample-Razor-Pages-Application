using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Razor_Pages_Application.Models
{
    public interface IRecipesService
    {
        Task DeleteAsync(long id);
        Recipe Find(long id);
        Task<Recipe> FindAsync(long id);
        IQueryable<Recipe> GetAll(int? count = null, int? page = null);
        Task<Recipe[]> GetAllAsync(int? count = null, int? page = null);
        Task SaveAsync(Recipe recipe);
    }
}
