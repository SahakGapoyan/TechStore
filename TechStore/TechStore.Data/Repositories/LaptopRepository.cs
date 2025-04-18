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
    public class LaptopRepository : ProductRepository<Laptop>, ILaptopRepository
    {
        public LaptopRepository(TechStoreDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Laptop>> GetLaptopsByMemoryId(int memoryId, CancellationToken token = default)
        {
            return await _dbSet.Where(l => l.ModelId == memoryId).ToListAsync(token);
        }

        public async Task<IEnumerable<Laptop>> GetLaptopsByOSId(int osId, CancellationToken token = default)
        {
            return await _dbSet.Where(l => l.OSId == osId).ToListAsync(token);
        }

        public async Task<IEnumerable<Laptop>> GetLaptopsByRamId(int ramId, CancellationToken token = default)
        {
            return await _dbSet.Where(l => l.RamId == ramId).ToListAsync(token);
        }
    }
}
