using TechStore.Blazor.DtoModels.Category;

namespace TechStore.Blazor.Interfaces
{
    public interface ICategoryApi
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategory(int id);
        Task AddCategory(CategoryAddDto categoryAddDto);
        Task DeleteCategory(int id);
        Task UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto);
    }
}
