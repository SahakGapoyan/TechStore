using TechStore.Blazor.DtoModels.Color;

namespace TechStore.Blazor.Interfaces
{
    public interface IColorApi
    {
        Task<IEnumerable<ColorDto>> GetColors();
        Task<ColorDto> GetColor(int id);
    }
}
