using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Laptop;
using TechStore.BLL.DtoModels.SmartPhone;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class LaptopService : ProductService<Laptop, LaptopDto, LaptopAddDto, LaptopUpdateDto>, ILaptopService
    {
        public LaptopService(IUnitOfWork uow, IMapper mapper,IServiceProvider serviceProvider) : base(uow, mapper, serviceProvider)
        {

        }
        public async Task<(Result, IEnumerable<LaptopDto>)> GetLaptopsByMemoryId(int memoryId, CancellationToken token = default)
        {
            var memory = await _uow.MemoryRepository.GetMemoryById(memoryId, token);

            if (memory == null)
                return (Result.Error(ErrorType.NotFound, $"Memory with {memoryId} MemoryId not found."), null);

            return (Result.Ok(), _mapper.Map<List<LaptopDto>>(await _uow.LaptopRepository.GetLaptopsByMemoryId(memoryId)));
        }

        public async Task<(Result, IEnumerable<LaptopDto>)> GetLaptopsByOSId(int osId, CancellationToken token = default)
        {
            var oS = await _uow.OSRepsoitory.GetOSById(osId, token);

            if (oS == null)
                return (Result.Error(ErrorType.NotFound, $"OS with {osId} OSId not found."), null);

            return (Result.Ok(), _mapper.Map<List<LaptopDto>>(await _uow.LaptopRepository.GetLaptopsByOSId(osId)));
        }

        public async Task<(Result, IEnumerable<LaptopDto>)> GetLaptopsByRamId(int ramId, CancellationToken token = default)
        {
            var ram = await _uow.RamRepository.GetRamById(ramId, token);

            if (ram == null)
                return (Result.Error(ErrorType.NotFound, $"Ram with {ramId} RamId not found."), null);

            return (Result.Ok(), _mapper.Map<List<LaptopDto>>(await _uow.LaptopRepository.GetLaptopsByRamId(ramId)));
        }

        public async Task<Result> UpdateLaptop(int laptopId, LaptopUpdateDto laptopUpdateDto, CancellationToken token = default)
        {
            var result = await base.UpdateProduct(laptopId, laptopUpdateDto, token);
            if (!result.Success)
                return result;

            var laptop = await _uow.LaptopRepository.GetProductById(laptopId, token);

            laptop.OSId = laptopUpdateDto.OsId ?? laptop.OSId;
            laptop.MemoryId = laptopUpdateDto.MemoryId ?? laptop.MemoryId;
            laptop.RamId = laptopUpdateDto.RamId ?? laptop.RamId;
            laptop.ScreenSize = laptopUpdateDto.ScreenSize ?? laptop.ScreenSize;
            laptop.Processor = laptopUpdateDto.Processor ?? laptop.Processor;
            laptop.BatteryLifeInHours = laptopUpdateDto.BatteryLifeInHours ?? laptop.BatteryLifeInHours;
            laptop.HasTouchScreen = laptopUpdateDto.HasTouchScreen ?? laptop.HasTouchScreen;
            laptop.HasFingerprintSensor = laptopUpdateDto.HasFingerprintSensor ?? laptop.HasFingerprintSensor;

            await _uow.LaptopRepository.UpdateProduct(laptop);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully updated.");
        }
    }
}
