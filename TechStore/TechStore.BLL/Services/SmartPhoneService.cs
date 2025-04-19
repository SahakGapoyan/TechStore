using AutoMapper;
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

namespace TechStore.BLL.Services
{
    public class SmartPhoneService
        : ProductService<SmartPhone, SmartPhoneDto, SmartPhoneAddDto, SmartPhoneUpdateDto>,
        ISmartPhoneService
    {
        public SmartPhoneService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }

        public async Task<(Result , IEnumerable<SmartPhoneDto>)> GetSmartPhonesByMemoryId(int memoryId, CancellationToken token = default)
        {
            var memory = await _uow.MemoryRepository.GetMemoryById(memoryId,token);

            if (memory == null)
                return (Result.Error(ErrorType.NotFound, $"Memory with {memoryId} MemoryId not found."), null);

            return (Result.Ok(),_mapper.Map<List<SmartPhoneDto>>(await _uow.SmartPhoneRepository.GetSmartPhonesByMemoryId(memoryId)));
        }

        public async Task<(Result, IEnumerable<SmartPhoneDto>)> GetSmartPhonesByOSID(int OSId, CancellationToken token = default)
        {
            var os = await _uow.OSRepsoitory.GetOSById(OSId, token);

            if(os==null)
                return (Result.Error(ErrorType.NotFound, $"Os with {OSId} OsId not found."), null);

            return (Result.Ok(),_mapper.Map<List<SmartPhoneDto>>(await _uow.SmartPhoneRepository.GetSmartPhonesByOSID(OSId)));
        }

        public async Task<(Result, IEnumerable<SmartPhoneDto>)> GetSmartPhonesByRamId(int ramId, CancellationToken token = default)
        {
            var ram = await _uow.RamRepository.GetRamById(ramId, token);

            if (ram == null)
                return (Result.Error(ErrorType.NotFound, $"Ram with {ramId} RamId not found."), null);

            return (Result.Ok(),_mapper.Map<List<SmartPhoneDto>>(await _uow.SmartPhoneRepository.GetSmartPhonesByRamId(ramId)));
        }
    }
}
