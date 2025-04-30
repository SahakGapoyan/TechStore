using TechStore.Blazor.DtoModels.Color;

namespace TechStore.Blazor.Interfaces
{
    public interface IColorApi
    {
        Task<IEnumerable<ColorDto>> GetColors();
        Task<ColorDto> GetColor(int id);
        Task<IEnumerable<ColorDto>> GetColorsByCategoryId(int categoryId);
        Task AddColor(ColorAddDto colorAddDto);
        Task UpdateColor(int colorId, ColorUpdateDto colorUpdateDto);
        Task DeleteColor(int colorId);
    }
}
