using TechStore.Blazor.DtoModels.Model;
using TechStore.Blazor.DtoModels.Result;

namespace TechStore.Blazor.Interfaces
{
    public interface IModelApi
    {
        Task<IEnumerable<ModelDto>> GetModels();
        Task<ModelDto> GetModel(int id);
        Task<IEnumerable<ModelDto>> GetModelsByCategoryId(int categoryId);
        Task<ApiResult<bool>> AddModel(ModelAddDto modelAddDto);
        Task UpdateModel(int modelId, ModelUpdateDto modelUpdateDto);
        Task DeleteModel(int modelId);
    }
}
