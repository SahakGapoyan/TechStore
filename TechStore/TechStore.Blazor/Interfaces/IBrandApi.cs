using TechStore.Blazor.DtoModels.Brand;
using TechStore.Blazor.DtoModels.Result;

namespace TechStore.Blazor.Interfaces
{
    public interface IBrandApi
    {
        Task<IEnumerable<BrandDto>> GetBrands();
        Task<IEnumerable<BrandDto>> GetBrandsByCategoryId(int categoryId);
        Task<BrandDto?> GetBrand(int brandId);
        Task<ApiResult<bool>> AddBrand(BrandAddDto brandAddDto);
        Task<ApiResult<bool>> UpdateBrand(int brandId, BrandUpdateDto brandUpdateDto);
        Task DeleteBrand(int brandId);
    }
}
