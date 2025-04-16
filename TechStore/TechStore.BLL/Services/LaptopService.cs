using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Laptop;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class LaptopService : ProductService<Laptop, LaptopDto, LaptopAddDto, LaptopUpdateDto>, ILaptopService
    {
        public LaptopService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }
        public async Task<IEnumerable<LaptopDto>> GetLaptopsByMemoryId(int memoryId, CancellationToken token = default)
        {
            return _mapper.Map<List<LaptopDto>>(await _uow.LaptopRepository.GetLaptopsByMemoryId(memoryId, token));
        }

        public async Task<IEnumerable<LaptopDto>> GetLaptopsByOSId(int osId, CancellationToken token = default)
        {
            return _mapper.Map<List<LaptopDto>>(await _uow.LaptopRepository.GetLaptopsByOSId(osId, token));
        }

        public async Task<IEnumerable<LaptopDto>> GetLaptopsByRamId(int ramId, CancellationToken token = default)
        {
            return _mapper.Map<List<LaptopDto>>(await _uow.LaptopRepository.GetLaptopsByRamId(ramId, token));
        }
    }
}
