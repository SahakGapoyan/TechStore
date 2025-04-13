using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.DbContext;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.Data.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly TechStoreDbContext _context;

        public BrandRepository(TechStoreDbContext context)
        {
            _context = context;
        }
        public async Task AddBrand(Brand brand, CancellationToken token = default)
        {
            await _context.Brands.AddAsync(brand, token);
        }

        public async Task DeleteBrand(Brand brand)
        {
            _context.Brands.Remove(brand);
        }

        public async Task<Brand?> GetBrand(int brandId, CancellationToken token = default)
        {
            return await _context.Brands.FirstOrDefaultAsync(b => b.Id == brandId);
        }

        public async Task<IEnumerable<Brand>> GetBrands(CancellationToken token = default)
        {
            return await _context.Brands.ToListAsync(token);
        }

        public async Task UpdateBrand(Brand brand)
        {
            _context.Brands.Update(brand);
        }
    }
}
