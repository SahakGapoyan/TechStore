﻿using System;
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
        Task<IEnumerable<T>> GetProductsByBrandId(int brandId, CancellationToken token = default);
        Task<IEnumerable<T>> GetProductsByColorId(int colorId, CancellationToken token = default);
        Task<IEnumerable<T>> GetProductsByModelId(int modelId, CancellationToken token = default);
        Task<IEnumerable<T>> GetProductSuggestions(string query, CancellationToken token = default);
        Task AddProduct(T product, CancellationToken token = default);
        Task UpdateProduct(T product);
        Task DeleteProduct(T product);
    }
}
