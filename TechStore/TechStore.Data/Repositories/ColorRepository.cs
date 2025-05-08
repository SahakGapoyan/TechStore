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
    public class ColorRepository : IColorRepository
    {
        private readonly TechStoreDbContext _context;

        public ColorRepository(TechStoreDbContext context)
        {
            _context = context;
        }
        public async Task AddColor(Color color, CancellationToken token = default)
        {
            await _context.Colors.AddAsync(color, token);
        }

        public async Task DeleteColor(Color color)
        {
            _context.Colors.Remove(color);
        }

        public async Task<Color?> GetColorById(int colorId, CancellationToken token = default)
        {
            return await _context.Colors.FirstOrDefaultAsync(c => c.Id == colorId, token);
        }

        public async Task<IEnumerable<Color>> GetColors(CancellationToken token = default)
        {
            return await _context.Colors.ToListAsync();
        }

        public async Task<IEnumerable<Color>> GetColorssByCategoryId(int categoryId, CancellationToken token = default)
        {
            return await _context.Colors.Where(c => c.Products.Any(e => e.CategoryId == categoryId)).ToListAsync(token);
        }

        public async Task UpdateColor(Color color)
        {
            _context.Colors.Update(color);
        }
    }
}
