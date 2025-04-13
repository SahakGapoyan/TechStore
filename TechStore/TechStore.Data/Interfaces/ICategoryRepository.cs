using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories(CancellationToken toke = default);
        Task<Category?> GetCategory(int id, CancellationToken token = default);
        Task AddCategory(Category category, CancellationToken toke = default);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Category category);
    }
}
