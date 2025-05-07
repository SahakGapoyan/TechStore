using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Brand;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public BrandService(IUnitOfWork uow, IMapper mapper,IServiceProvider serviceProvider)
        {
            _uow = uow;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public async Task<Result> AddBrand(BrandAddDto brandAddDto, CancellationToken token = default)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<BrandAddDto>>();
            var validationResult = await validator.ValidateAsync(brandAddDto, token);
            if (!validationResult.IsValid)
                return Result.ValidationError(validationResult.Errors);

            var brand = _mapper.Map<Brand>(brandAddDto);
            await _uow.BrandRepository.AddBrand(brand, token);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully created.");
        }

        public async Task<Result> DeleteBrand(int brandId, CancellationToken token = default)
        {
            var brand = await _uow.BrandRepository.GetBrand(brandId);

            if (brand == null)
                return Result.Error(ErrorType.NotFound);

            await _uow.BrandRepository.DeleteBrand(brand);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully deleted.");

        }

        public async Task<BrandDto?> GetBrand(int brandId, CancellationToken token = default)
        {
            return _mapper.Map<BrandDto>(await _uow.BrandRepository.GetBrand(brandId, token));
        }

        public async Task<IEnumerable<BrandDto>> GetBrands(CancellationToken token = default)
        {
            var brands = await _uow.BrandRepository.GetBrands(token);
            return _mapper.Map<List<BrandDto>>(brands);

        }

        public async Task<IEnumerable<BrandDto>> GetBrandsByCategoryId(int categoryId, CancellationToken token = default)
        {
            var brands=await _uow.BrandRepository.GetBrandsByCategoryId(categoryId, token);
            return _mapper.Map<List<BrandDto>>(brands);
        }

        public async Task<Result> UpdateBrand(int brandId, BrandUpdateDto brandUpdateDto, CancellationToken token = default)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<BrandUpdateDto>>();
            var validationResult = await validator.ValidateAsync(brandUpdateDto, token);
            if (!validationResult.IsValid)
                return Result.ValidationError(validationResult.Errors);

            var brand = await _uow.BrandRepository.GetBrand(brandId, token);

            if (brand == null)
                return Result.Error(ErrorType.NotFound);

            brand.Name = brandUpdateDto.Name ?? brand.Name;
            brand.ImageUrl=brandUpdateDto.ImageUrl?? brand.ImageUrl;    

            await _uow.BrandRepository.UpdateBrand(brand);
            await _uow.SaveAsync(token);
            return Result.Ok("Successfully updated.");
        }
    }
}
