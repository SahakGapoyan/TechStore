using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface IProductRepository<T> where T : Product
    {
        Task<T?> GetProductById(int productId, CancellationToken token = default);
        Task<IEnumerable<T>> GetProducts(CancellationToken token = default);
        Task AddProduct(T product, CancellationToken token = default);
        Task UpdateProduct(T product);
        Task DeleteProduct(T product);
    }
}
