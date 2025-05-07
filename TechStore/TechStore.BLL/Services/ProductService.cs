using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Product;
using TechStore.BLL.DtoModels.SmartPhone;
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
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        protected readonly IServiceProvider _serviceProvider;

        public ProductService(IUnitOfWork uow, IMapper mapper, IServiceProvider serviceProvider)
        {
            _uow = uow;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public async Task<Result> AddProduct(TProductAddDto productAddDto, CancellationToken token = default)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<TProductAddDto>>();
            var validationResult = await validator.ValidateAsync(productAddDto, token);
            if (!validationResult.IsValid)
                return Result.ValidationError(validationResult.Errors);

            var productMap = _mapper.Map<TProduct>(productAddDto);
            var product = await _uow.GetProductRepository<Product>(token);
            await product.AddProduct(productMap);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully deleted.");

        }

        public async Task<Result> DeleteProduct(int tProductId, CancellationToken token = default)
        {
            var repo = await _uow.GetProductRepository<TProduct>(token);
            var product = await repo.GetProductById(tProductId, token);

            if (product == null)
                return Result.Error(ErrorType.NotFound);

            await repo.DeleteProduct(product);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully deleted.");
        }

        public async Task<TProductDto?> GetProductById(int productId, CancellationToken token = default)
        {
            var repo = await _uow.GetProductRepository<TProduct>(token);
            var product = await repo.GetProductById(productId, token);
            return _mapper.Map<TProductDto>(product);
        }

        public async Task<IEnumerable<TProductDto>> GetProducts(CancellationToken token = default)
        {
            var repo = await _uow.GetProductRepository<TProduct>(token);
            var products = await repo.GetProducts(token);
            return _mapper.Map<List<TProductDto>>(products);
        }
        public async Task<(Result, IEnumerable<TProductDto>)> GetProductsByBrandId(int brandId, CancellationToken token = default)
        {
            var repo = await _uow.GetProductRepository<TProduct>(token);
            var brand = await _uow.BrandRepository.GetBrand(brandId, token);

            if (brand == null)
                return (Result.Error(ErrorType.NotFound, $"Brand with {brandId} BrandId not found."), null);

            return (Result.Ok(), _mapper.Map<List<TProductDto>>(await repo.GetProductsByBrandId(brandId)));
        }

        public async Task<(Result, IEnumerable<TProductDto>)> GetProductsByColorId(int colorId, CancellationToken token = default)
        {
            var repo = await _uow.GetProductRepository<TProduct>(token);
            var color = await _uow.ColorRepository.GetColorById(colorId, token);

            if (color == null)
                return (Result.Error(ErrorType.NotFound, $"Color with {colorId} ColorId not found."), null);

            return (Result.Ok(), _mapper.Map<List<TProductDto>>(await repo.GetProductsByColorId(colorId)));
        }

        public async Task<(Result, IEnumerable<TProductDto>)> GetProductsByModelId(int modelId, CancellationToken token = default)
        {
            var repo = await _uow.GetProductRepository<TProduct>(token);
            var model = await _uow.ModelRepository.GetModel(modelId, token);

            if (model == null)
                return (Result.Error(ErrorType.NotFound, $"Model with {modelId} ModelId not found."), null);

            return (Result.Ok(), _mapper.Map<List<TProductDto>>(await repo.GetProductsByModelId(modelId)));
        }

        public async Task<IEnumerable<TProductDto>> GetProductSuggestions(string query, CancellationToken token = default)
        {
            var repo = await _uow.GetProductRepository<TProduct>(token);
            var products = await repo.GetProductSuggestions(query, token);

            return _mapper.Map<List<TProductDto>>(products);
        }

        public async Task<Result> UpdateProduct(int tProductId, TProductUpdateDto productUpdateDto, CancellationToken token = default)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<TProductUpdateDto>>();
            var validationResult = await validator.ValidateAsync(productUpdateDto, token);
            if (!validationResult.IsValid)
                return Result.ValidationError(validationResult.Errors);

            var repo = await _uow.GetProductRepository<TProduct>(token);
            var product = await repo.GetProductById(tProductId, token);

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
            product.ImagesUrls = productUpdateDto.ImagesUrls ?? product.ImagesUrls;

            return Result.Ok();
        }


    }
}
