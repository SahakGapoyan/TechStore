using TechStore.Blazor.DtoModels.Brand;

namespace TechStore.Blazor.Interfaces
{
    public interface IBrandApi
    {
        Task<IEnumerable<BrandDto>> GetBrands();
        Task<IEnumerable<BrandDto>> GetBrandsByCategoryId(int categoryId);
        Task<BrandDto?> GetBrand(int brandId);
        Task AddBrand(BrandAddDto brandAddDto);
        Task UpdateBrand(int brandId, BrandUpdateDto brandUpdateDto);
        Task DeleteBrand(int brandId);
    }
}
