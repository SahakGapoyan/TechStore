﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Product;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface IProductService<TProduct, TProductDto, TProductAddDto, TProductUpdateDto>
        where TProduct : Product
        where TProductDto : ProductDto
        where TProductAddDto : ProductAddDto
        where TProductUpdateDto : ProductUpdateDto
    {
        Task<TProductDto?> GetProductById(int productId, CancellationToken token = default);
        Task<IEnumerable<TProductDto>> GetProducts(CancellationToken token = default);
        Task<(Result, IEnumerable<TProductDto>)> GetProductsByBrandId(int brandId, CancellationToken token = default);
        Task<(Result, IEnumerable<TProductDto>)> GetProductsByColorId(int colorId, CancellationToken token = default);
        Task<(Result, IEnumerable<TProductDto>)> GetProductsByModelId(int modelId, CancellationToken token = default);
        Task<IEnumerable<TProductDto>> GetProductSuggestions(string query,CancellationToken token=default);
        Task<Result> AddProduct(TProductAddDto productAddDto, CancellationToken token = default);
        Task<Result> UpdateProduct(int tProductId, TProductUpdateDto productUpdateDto, CancellationToken token = default);
        Task<Result> DeleteProduct(int tProductId, CancellationToken token = default);
    }
}
