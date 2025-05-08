using TechStore.Blazor.DtoModels.Color;
using TechStore.Blazor.DtoModels.Result;

namespace TechStore.Blazor.Interfaces
{
    public interface IColorApi
    {
        Task<IEnumerable<ColorDto>> GetColors();
        Task<ColorDto> GetColor(int id);
        Task<IEnumerable<ColorDto>> GetColorsByCategoryId(int categoryId);
        Task<ApiResult<bool>> AddColor(ColorAddDto colorAddDto);
        Task UpdateColor(int colorId, ColorUpdateDto colorUpdateDto);
        Task DeleteColor(int colorId);
    }
}
