using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.DbContext;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TechStoreDbContext _context;

        public CategoryRepository(TechStoreDbContext context)
        {
            _context = context;
        }
        public async Task AddCategory(Category category, CancellationToken token = default)
        {
            await _context.Categories.AddAsync(category, token);
        }

        public async Task DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task<IEnumerable<Category>> GetCategories(CancellationToken token = default)
        {
            return await _context.Categories.ToListAsync(token);
        }

        public async Task<Category?> GetCategory(int id, CancellationToken token = default)
        {
           return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
