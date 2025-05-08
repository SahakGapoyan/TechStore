using TechStore.Blazor.DtoModels.Result;
using TechStore.Blazor.DtoModels.Tv;

namespace TechStore.Blazor.Interfaces
{
    public interface ITvApi
    {
        Task<IEnumerable<TvDto>> GetTvs();
        Task<TvDto> GetTv(int id);
        Task<IEnumerable<TvDto>> GetTvsByBrandId(int brandId);
        Task<IEnumerable<TvDto>> GetTvsByColorId(int colorId);
        Task<IEnumerable<TvDto>> GetTvsByModelId(int modelId);
        Task<ApiResult<bool>> AddTv(TvAddDto tvAddDto);
        Task UpdateTv(int tvId, TvUpdateDto tvUpdateDto);
        Task DeleteTv(int tvId);
    }
}
