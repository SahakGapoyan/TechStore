using TechStore.Blazor.DtoModels.Category;
using TechStore.Blazor.DtoModels.Result;

namespace TechStore.Blazor.Interfaces
{
    public interface ICategoryApi
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategory(int id);
        Task<ApiResult<bool>> AddCategory(CategoryAddDto categoryAddDto);
        Task DeleteCategory(int id);
        Task<ApiResult<bool>> UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto);
    }
}
