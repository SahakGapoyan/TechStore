using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Memory;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface IMemoryService
    {
        Task<IEnumerable<MemoryDto>> GetMemories(CancellationToken token = default);
        Task<MemoryDto?> GetMemoryById(int memoryId, CancellationToken token = default);
        Task<IEnumerable<MemoryDto>> GetMemoriesByCategoryId(int categoryId, CancellationToken token = default);
        Task AddMemory(MemoryAddDto memoryAddDto, CancellationToken token = default);
        Task<Result> UpdateMemory(int memoryId, MemoryUpdateDto memoryUpdateDto, CancellationToken token = default);
        Task<Result> DeleteMemory(int memoryId,CancellationToken token=default);
    }
}
