using TechStore.Blazor.DtoModels.Color;
using TechStore.Blazor.DtoModels.Memory;
using TechStore.Blazor.DtoModels.Result;

namespace TechStore.Blazor.Interfaces
{
    public interface IMemoryApi
    {
        Task<IEnumerable<MemoryDto>> GetMemories();
        Task<MemoryDto> GetMemory(int id);
        Task<IEnumerable<MemoryDto>> GetMemoriesByCategoryId(int categoryId);
        Task<ApiResult<bool>> AddMemory(MemoryAddDto memoryAddDto);
        Task<ApiResult<bool>> UpdateMemory(int memoryId, MemoryUpdateDto memoryUpdateDto);
        Task DeleteMemory(int memoryId);
    }
}
