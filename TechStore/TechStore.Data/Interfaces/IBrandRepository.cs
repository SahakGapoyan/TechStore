using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetBrands(CancellationToken token = default);
        Task<Brand?> GetBrand(int brandId, CancellationToken token = default);
        Task<IEnumerable<Brand>> GetBrandsByCategoryId(int categoryId, CancellationToken token = default);  
        Task AddBrand(Brand brand, CancellationToken token = default);
        Task UpdateBrand(Brand brand);
        Task DeleteBrand(Brand brand);
    }
}
