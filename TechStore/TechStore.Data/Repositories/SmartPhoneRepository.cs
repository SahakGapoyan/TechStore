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
    public class SmartPhoneRepository:ProductRepository<SmartPhone>,ISmartPhoneRepository
    {
        public SmartPhoneRepository(TechStoreDbContext context):base(context)
        {
        }

        public async Task<IEnumerable<SmartPhone>> GetSmartPhonesByColorId(int colorId, CancellationToken token = default)
        {
            return await _dbSet.Where(s => s.ColorId == colorId).ToListAsync(token);
        }

        public async Task<IEnumerable<SmartPhone>> GetSmartPhonesByMemoryId(int memoryId, CancellationToken token = default)
        {
            return await _dbSet.Where(s => s.MemoryId == memoryId).ToListAsync(token);
        }

        public async Task<IEnumerable<SmartPhone>> GetSmartPhonesByOSID(int oSId, CancellationToken token = default)
        {
            return await _dbSet.Where(s => s.OSId == oSId).ToListAsync(token);
        }

        public async Task<IEnumerable<SmartPhone>> GetSmartPhonesByRamId(int ramId, CancellationToken token = default)
        {
            return await _dbSet.Where(s => s.RamId == ramId).ToListAsync(token);
        }
    }
}
