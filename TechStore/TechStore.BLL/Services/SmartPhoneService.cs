using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.SmartPhone;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;
using TechStore.Data.Repositories;

namespace TechStore.BLL.Services
{
    public class SmartPhoneService
        : ProductService<SmartPhone, SmartPhoneDto, SmartPhoneAddDto, SmartPhoneUpdateDto>,
        ISmartPhoneService
    {
        public SmartPhoneService(IUnitOfWork uow, IMapper mapper, IServiceProvider serviceProvider) : base(uow, mapper, serviceProvider)
        {

        }
        public async Task<(Result, IEnumerable<SmartPhoneDto>)> GetSmartPhonesByMemoryId(int memoryId, CancellationToken token = default)
        {
            var memory = await _uow.MemoryRepository.GetMemoryById(memoryId, token);

            if (memory == null)
                return (Result.Error(ErrorType.NotFound, $"Memory with {memoryId} MemoryId not found."), null);

            return (Result.Ok(), _mapper.Map<List<SmartPhoneDto>>(await _uow.SmartPhoneRepository.GetSmartPhonesByMemoryId(memoryId)));
        }

        public async Task<(Result, IEnumerable<SmartPhoneDto>)> GetSmartPhonesByOSId(int OSId, CancellationToken token = default)
        {
            var os = await _uow.OSRepsoitory.GetOSById(OSId, token);

            if (os == null)
                return (Result.Error(ErrorType.NotFound, $"Os with {OSId} OsId not found."), null);

            return (Result.Ok(), _mapper.Map<List<SmartPhoneDto>>(await _uow.SmartPhoneRepository.GetSmartPhonesByOSID(OSId)));
        }

        public async Task<(Result, IEnumerable<SmartPhoneDto>)> GetSmartPhonesByRamId(int ramId, CancellationToken token = default)
        {
            var ram = await _uow.RamRepository.GetRamById(ramId, token);

            if (ram == null)
                return (Result.Error(ErrorType.NotFound, $"Ram with {ramId} RamId not found."), null);

            return (Result.Ok(), _mapper.Map<List<SmartPhoneDto>>(await _uow.SmartPhoneRepository.GetSmartPhonesByRamId(ramId)));
        }
        public async Task<Result> UpdateSmartPhone(int smartPhoneId, SmartPhoneUpdateDto smartPhoneUpdateDto, CancellationToken token = default)
        {
            var result = await base.UpdateProduct(smartPhoneId, smartPhoneUpdateDto, token);
            if (!result.Success)
                return result;

            var smartPhone = await _uow.SmartPhoneRepository.GetProductById(smartPhoneId, token);

            smartPhone.OSId = smartPhoneUpdateDto.OSId ?? smartPhone.OSId;
            smartPhone.MemoryId = smartPhoneUpdateDto.MemoryId ?? smartPhone.MemoryId;
            smartPhone.RamId = smartPhoneUpdateDto.RamId ?? smartPhone.RamId;
            smartPhone.ScreenSize = smartPhoneUpdateDto.ScreenSize ?? smartPhone.ScreenSize;
            smartPhone.Processor = smartPhoneUpdateDto.Processor ?? smartPhone.Processor;
            smartPhone.BatteryCapacity = smartPhoneUpdateDto.BatteryCapacity ?? smartPhone.BatteryCapacity;
            smartPhone.CameraMegaPixel = smartPhoneUpdateDto.CameraMegaPixel ?? smartPhone.CameraMegaPixel;
            smartPhone.Has5G = smartPhoneUpdateDto.Has5G ?? smartPhone.Has5G;
            smartPhone.IsWaterResistant = smartPhoneUpdateDto.IsWaterResistant ?? smartPhone.IsWaterResistant;
            smartPhone.Wifi = smartPhoneUpdateDto.Wifi ?? smartPhone.Wifi;

            await _uow.SmartPhoneRepository.UpdateProduct(smartPhone);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully updated.");
        }
    }
}
