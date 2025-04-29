using TechStore.Blazor.DtoModels.Memory;

namespace TechStore.Blazor.Interfaces
{
    public interface IMemoryApi
    {
        Task<IEnumerable<MemoryDto>> GetMemories();
        Task<MemoryDto> GetMemory(int id);
        Task<IEnumerable<MemoryDto>> GetMemoriesByCategoryId(int categoryId);
    }
}
