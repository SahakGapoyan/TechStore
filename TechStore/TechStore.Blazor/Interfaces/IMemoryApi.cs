using TechStore.Blazor.DtoModels.Color;
using TechStore.Blazor.DtoModels.Memory;

namespace TechStore.Blazor.Interfaces
{
    public interface IMemoryApi
    {
        Task<IEnumerable<MemoryDto>> GetMemories();
        Task<MemoryDto> GetMemory(int id);
        Task<IEnumerable<MemoryDto>> GetMemoriesByCategoryId(int categoryId);
        Task AddMemory(MemoryAddDto memoryAddDto);
        Task UpdateMemory(int memoryId, MemoryUpdateDto memoryUpdateDto);
        Task DeleteMemory(int memoryId);
    }
}
