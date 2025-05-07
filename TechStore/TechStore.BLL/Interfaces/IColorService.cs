using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Color;

namespace TechStore.BLL.Interfaces
{
    public interface IColorService
    {
        Task<IEnumerable<ColorDto>> GetColors(CancellationToken token);
        Task<ColorDto?> GetColorById(int colorId, CancellationToken token = default);
        Task<IEnumerable<ColorDto>> GetColorsByCategoryId(int categoryId, CancellationToken token = default);
        Task<Result> AddColor(ColorAddDto colorAddDto, CancellationToken token = default);
        Task<Result> UpdateColor(int colorId,ColorUpdateDto colorUpdateDto, CancellationToken token = default);
        Task<Result> DeleteColor(int colorId, CancellationToken token = default);
    }
}
