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
    public class OSRepository : IOSRepsoitory
    {
        private readonly TechStoreDbContext _context;

        public OSRepository(TechStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddOS(OS oS, CancellationToken token = default)
        {
            await _context.OSs.AddAsync(oS, token);
        }

        public async Task DeleteOS(OS oS)
        {
            _context.OSs.Remove(oS);
        }

        public async Task<OS?> GetOSById(int osId, CancellationToken token = default)
        {
            return await _context.OSs.FirstOrDefaultAsync(os => os.Id == osId, token);
        }

        public async Task<IEnumerable<OS>> GetOsesByCategoryId(int categoryId, CancellationToken token = default)
        {
            return await _context.OSs
                         .Where(o =>
                             o.SmartPhones.Any(s => s.CategoryId == categoryId) ||
                             o.Laptops.Any(l => l.CategoryId == categoryId)
                         )
                         .ToListAsync(token);
        }

        public async Task<IEnumerable<OS>> GetOSs(CancellationToken token = default)
        {
            return await _context.OSs.ToListAsync();
        }

        public async Task UpdateOS(OS oS)
        {
            _context.OSs.Update(oS);
        }
    }
}
