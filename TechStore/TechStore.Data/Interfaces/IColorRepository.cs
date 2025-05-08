using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface IColorRepository
    {
        Task<IEnumerable<Color>> GetColors(CancellationToken token = default);
        Task<Color?> GetColorById(int colorId, CancellationToken token = default);
        Task<IEnumerable<Color>> GetColorssByCategoryId(int categoryId, CancellationToken token = default);
        Task AddColor(Color color, CancellationToken token = default);
        Task UpdateColor(Color color);
        Task DeleteColor(Color color);
    }
}
