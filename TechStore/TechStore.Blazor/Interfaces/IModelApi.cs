using TechStore.Blazor.DtoModels.Model;

namespace TechStore.Blazor.Interfaces
{
    public interface IModelApi
    {
        Task<IEnumerable<ModelDto>> GetModels();
        Task<ModelDto> GetModel(int id);
        Task<IEnumerable<ModelDto>> GetModelsByCategoryId(int? categoryId);
    }
}
