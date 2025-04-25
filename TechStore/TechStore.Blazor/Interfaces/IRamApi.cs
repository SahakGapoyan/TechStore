using TechStore.Blazor.DtoModels.Ram;

namespace TechStore.Blazor.Interfaces
{
    public interface IRamApi
    {
        Task<IEnumerable<RamDto>> GetRams();
        Task<RamDto> GetRam(int id);
    }
}
