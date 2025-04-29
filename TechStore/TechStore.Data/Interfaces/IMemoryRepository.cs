using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface IMemoryRepository
    {
        Task<IEnumerable<Memory>> GetMemories(CancellationToken token = default);
        Task<Memory?> GetMemoryById(int memoryId, CancellationToken token = default);
        Task<IEnumerable<Memory>> GetMemoriesByCategoryId(int categoryId, CancellationToken token = default);
        Task AddMemory(Memory memory, CancellationToken token = default);
        Task UpdateMemory(Memory memory);
        Task DeleteMemory(Memory memory);
    }
}
