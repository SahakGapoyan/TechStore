using TechStore.Blazor.DtoModels.OS;

namespace TechStore.Blazor.Interfaces
{
    public interface IOSApi
    {
        Task<IEnumerable<OSDto>> GetOSes();
        Task<OSDto> GetOS(int id);
        Task<IEnumerable<OSDto>> GetOsesByCategoryId(int categoryId);
        Task AddOS(OSAddDto osAddDto);
        Task UpdateOS(int osId, OSUpdateDto osUpdateDto);
        Task DeleteOS(int osId);
    }
}
