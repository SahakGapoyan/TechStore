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
    public class ProductRepository<T> : IProductRepository<T> where T : Product
    {
        protected readonly DbSet<T> _dbSet;
        private readonly TechStoreDbContext _context;

        public ProductRepository(TechStoreDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task AddProduct(T product, CancellationToken token = default)
        {
            await _dbSet.AddAsync(product,token);
        }

        public async Task DeleteProduct(T product)
        {
            _dbSet.Remove(product);
        }

        public async Task<T?> GetProductById(int productId, CancellationToken token = default)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Id == productId, token);
        }

        public async Task<IEnumerable<T>> GetProducts(CancellationToken token = default)
        {
            return await _dbSet.ToListAsync(token);
        }

        public async Task UpdateProduct(T product)
        {
            _dbSet.Update(product);
        }
    }
}
