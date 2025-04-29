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
    public class MemoryRepository : IMemoryRepository
    {
        private readonly TechStoreDbContext _context;

        public MemoryRepository(TechStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddMemory(Memory memory, CancellationToken token = default)
        {
            await _context.Memories.AddAsync(memory, token);
        }

        public async Task DeleteMemory(Memory memory)
        {
            _context.Memories.Remove(memory);
        }

        public async Task<IEnumerable<Memory>> GetMemories(CancellationToken token = default)
        {
            return await _context.Memories.ToListAsync(token);
        }

        public async Task<IEnumerable<Memory>> GetMemoriesByCategoryId(int categoryId, CancellationToken token = default)
        {
            return await _context.Memories
                    .Where(m =>
                        m.SmartPhones.Any(s => s.CategoryId == categoryId) ||
                        m.Laptops.Any(l => l.CategoryId == categoryId)
                    )
                    .ToListAsync(token);
        }

        public async Task<Memory?> GetMemoryById(int memoryId, CancellationToken token = default)
        {
            return await _context.Memories.FirstOrDefaultAsync(m => m.Id == memoryId, token);
        }

        public async Task UpdateMemory(Memory memory)
        {
            _context.Memories.Update(memory);
        }
    }
}
