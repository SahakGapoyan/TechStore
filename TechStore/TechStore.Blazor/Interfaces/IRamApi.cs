using TechStore.Blazor.DtoModels.Ram;
using TechStore.Blazor.DtoModels.Result;

namespace TechStore.Blazor.Interfaces
{
    public interface IRamApi
    {
        Task<IEnumerable<RamDto>> GetRams();
        Task<RamDto> GetRam(int id);
        Task<IEnumerable<RamDto>> GetRamsByCategoryId(int categoryId);
        Task<ApiResult<bool>> AddRam(RamAddDto ramAddDto);
        Task<ApiResult<bool>> UpdateRam(int ramId, RamUpdateDto ramUpdateDto);
        Task DeleteRam(int ramId);
    }
}
