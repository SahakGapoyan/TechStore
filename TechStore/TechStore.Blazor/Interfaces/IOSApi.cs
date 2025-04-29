using TechStore.Blazor.DtoModels.OS;

namespace TechStore.Blazor.Interfaces
{
    public interface IOSApi
    {
        Task<IEnumerable<OSDto>> GetOSes();
        Task<OSDto> GetOS(int id);
        Task<IEnumerable<OSDto>> GetOsesByCategoryId(int? categoryId);
    }
}
