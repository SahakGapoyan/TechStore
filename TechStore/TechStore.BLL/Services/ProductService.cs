using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Product;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class ProductService<TProduct, TProductDto, TProductAddDto, TProductUpdateDto>
        : IProductService<TProduct, TProductDto, TProductAddDto, TProductUpdateDto>
        where TProduct : Product
        where TProductDto : ProductDto
        where TProductAddDto : ProductAddDto
        where TProductUpdateDto : ProductUpdateDto
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddProduct(TProductAddDto productAddDto, CancellationToken token = default)
        {
            var productMap = _mapper.Map<TProduct>(productAddDto);
            var product = await _uow.GetProductRepository<Product>(token);
            await product.AddProduct(productMap);
            await _uow.SaveAsync(token);
        }

        public async Task<Result> DeleteProduct(int tProductId, CancellationToken token = default)
        {
            var mockProduct = await _uow.GetProductRepository<TProduct>(token);
            var product = await mockProduct.GetProductById(tProductId, token);

            if (product == null)
                return Result.Error(ErrorType.NotFound);

            await mockProduct.DeleteProduct(product);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully deleted.");
        }

        public async Task<TProductDto?> GetProductById(int productId, CancellationToken token = default)
        {
            var mockProduct = await _uow.GetProductRepository<TProduct>(token);
            var product = await mockProduct.GetProductById(productId, token);
            return _mapper.Map<TProductDto>(product);
        }

        public async Task<IEnumerable<TProductDto>> GetProducts(CancellationToken token = default)
        {
            var mockProduct = await _uow.GetProductRepository<TProduct>(token);
            var products = await mockProduct.GetProducts(token);
            return _mapper.Map<List<TProductDto>>(products);
        }

        public async Task<Result> UpdateProduct(int tProductId, TProductUpdateDto productUpdateDto, CancellationToken token = default)
        {
            var mockProduct = await _uow.GetProductRepository<TProduct>(token);
            var product = await mockProduct.GetProductById(tProductId, token);

            if (product == null)
                return Result.Error(ErrorType.NotFound);

            product.BrandId = productUpdateDto.BrandId ?? product.BrandId;
            product.ColorId = productUpdateDto.ColorId ?? product.ColorId;
            product.Name = productUpdateDto.Name ?? product.Name;
            product.Description = productUpdateDto.Description ?? product.Description;
            product.IsAvailable = productUpdateDto.IsAvailable ?? product.IsAvailable;
            product.CategoryId = productUpdateDto.CategoryId ?? product.CategoryId;
            product.Price = productUpdateDto.Price ?? product.Price;
            product.ModelId = productUpdateDto.ModelId ?? product.ModelId;

            await mockProduct.UpdateProduct(product);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully updated.");
        }
    }
}
