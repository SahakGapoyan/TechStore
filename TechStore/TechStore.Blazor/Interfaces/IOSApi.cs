using TechStore.Blazor.DtoModels.OS;
using TechStore.Blazor.DtoModels.Result;

namespace TechStore.Blazor.Interfaces
{
    public interface IOSApi
    {
        Task<IEnumerable<OSDto>> GetOSes();
        Task<OSDto> GetOS(int id);
        Task<IEnumerable<OSDto>> GetOsesByCategoryId(int categoryId);
        Task<ApiResult<bool>> AddOS(OSAddDto osAddDto);
        Task<ApiResult<bool>> UpdateOS(int osId, OSUpdateDto osUpdateDto);
        Task DeleteOS(int osId);
    }
}
