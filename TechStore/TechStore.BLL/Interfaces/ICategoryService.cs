using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Category;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories(CancellationToken token = default);
        Task<CategoryDto?> GetCategory(int id, CancellationToken token = default);
        Task<Result> AddCategory(CategoryAddDto categoryAddDto, CancellationToken token = default);
        Task<Result> UpdateCategory(int categoryId,CategoryUpdateDto categoryUpdateDto, CancellationToken token = default);
        Task<Result> DeleteCategory(int categoryId, CancellationToken token = default);
    }
}
