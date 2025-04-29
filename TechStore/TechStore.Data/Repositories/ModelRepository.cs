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
    public class ModelRepository : IModelRepository
    {
        private readonly TechStoreDbContext _context;

        public ModelRepository(TechStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddModel(Model model, CancellationToken token = default)
        {
           await _context.Models.AddAsync(model, token);
        }

        public async Task Delete(Model model)
        {
            _context.Models.Remove(model);
        }

        public async Task<Model?> GetModel(int modelId, CancellationToken token = default)
        {
            return await _context.Models.FirstOrDefaultAsync(m => m.Id == modelId);
        }

        public async Task<IEnumerable<Model>> GetModels(CancellationToken token = default)
        {
            return await _context.Models.ToListAsync(token);
        }

        public async Task<IEnumerable<Model>> GetModelsByCategoryId(int categoryId, CancellationToken token = default)
        {
            return await _context.Models.Where(m => m.Products.Any(e => e.CategoryId == categoryId)).ToListAsync(token);
        }

        public async Task Update(Model model)
        {
            _context.Models.Update(model);
        }
    }
}
