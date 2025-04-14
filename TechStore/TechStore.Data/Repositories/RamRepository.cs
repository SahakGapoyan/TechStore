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
    public class RamRepository : IRamRepository
    {
        private readonly TechStoreDbContext _context;

        public RamRepository(TechStoreDbContext context)
        {
            _context = context;
        }
        public async Task AddRam(Ram ram, CancellationToken token = default)
        {
            await _context.Rams.AddAsync(ram, token);
        }

        public async Task DeleteRam(Ram ram)
        {
            _context.Rams.Remove(ram);
        }

        public async Task<Ram?> GetRamById(int ramId, CancellationToken token = default)
        {
            return await _context.Rams.FirstOrDefaultAsync(r => r.Id == ramId, token);
        }

        public async Task<IEnumerable<Ram>> GetRams(CancellationToken token)
        {
            return await _context.Rams.ToListAsync();
        }

        public async Task UpdateRam(Ram ram)
        {
            _context.Rams.Update(ram);
        }
    }
}
