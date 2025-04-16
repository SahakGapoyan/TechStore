using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.SmartPhone;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class SmartPhoneService
        :ProductService<SmartPhone,SmartPhoneDto,SmartPhoneAddDto,SmartPhoneUpdateDto>,
        ISmartPhoneService
    {
        public SmartPhoneService(IUnitOfWork uow,IMapper mapper):base(uow,mapper)
        {
            
        }

        public async Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByMemoryId(int memoryId, CancellationToken token = default)
        {
            return _mapper.Map<List<SmartPhoneDto>>(await _uow.SmartPhoneRepository.GetSmartPhonesByMemoryId(memoryId));
        }

        public async Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByOSID(int OSId, CancellationToken token = default)
        {
            return _mapper.Map<List<SmartPhoneDto>>(await _uow.SmartPhoneRepository.GetSmartPhonesByOSID(OSId));
        }

        public async Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByRamId(int ramId, CancellationToken token = default)
        {
            return _mapper.Map<List<SmartPhoneDto>>(await _uow.SmartPhoneRepository.GetSmartPhonesByRamId(ramId));
        }
    }
}
