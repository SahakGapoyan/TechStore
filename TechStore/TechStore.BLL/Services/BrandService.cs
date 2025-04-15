using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Brand;
using TechStore.BLL.DtoModels.Enums;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddBrand(BrandAddDto brandAddDto, CancellationToken token = default)
        {
            var brand = _mapper.Map<Brand>(brandAddDto);
            await _uow.BrandRepository.AddBrand(brand, token);
            await _uow.SaveAsync(token);
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

        public async Task<Result> UpdateBrand(int brandId, BrandUpdateDto brandUpdateDto, CancellationToken token = default)
        {
            var brand = await _uow.BrandRepository.GetBrand(brandId, token);

            if (brand == null)
                return Result.Error(ErrorType.NotFound);

            brand.Name = brandUpdateDto.Name ?? brand.Name;

            await _uow.SaveAsync(token);
            return Result.Ok("Successfully updated.");
        }
    }
}
