using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Brand;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetBrands(CancellationToken token = default);
        Task<IEnumerable<BrandDto>> GetBrandsByCategoryId(int categoryId,CancellationToken token = default);
        Task<BrandDto?> GetBrand(int brandId, CancellationToken token = default);
        Task<Result> AddBrand(BrandAddDto brandAddDto, CancellationToken token = default);
        Task<Result> UpdateBrand(int brandId,BrandUpdateDto brandUpdateDto,CancellationToken token=default);
        Task<Result> DeleteBrand(int brandId,CancellationToken token=default);
    }
}
