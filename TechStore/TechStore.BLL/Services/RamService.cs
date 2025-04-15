using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Ram;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class RamService : IRamService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RamService(IUnitOfWork uow,IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddRam(RamAddDto ramAddDto, CancellationToken token = default)
        {
            var ram = _mapper.Map<Ram>(ramAddDto);
            await _uow.RamRepository.AddRam(ram,token);
            await _uow.SaveAsync(token);
        }

        public async Task<Result> DeleteRam(int ramId, CancellationToken token = default)
        {
            var ram = await _uow.RamRepository.GetRamById(ramId);
            if(ram==null)
            {
                return Result.Error(ErrorType.NotFound);
            }
            await _uow.RamRepository.DeleteRam(ram);
            await _uow.SaveAsync(token);
            return Result.Ok("Successfully deleted");
        }

        public async Task<RamDto?> GetRamById(int ramId, CancellationToken token = default)
        {
            return _mapper.Map<RamDto>(await _uow.RamRepository.GetRamById(ramId, token));
        }

        public async Task<IEnumerable<RamDto>> GetRams(CancellationToken token)
        {
            var rams = await _uow.RamRepository.GetRams(token);
            return _mapper.Map<List<RamDto>>(rams);
        }

        public async Task<Result> UpdateRam(int ramId, RamUpdateDto ramUpdateDto, CancellationToken token = default)
        {
            var ram = await _uow.RamRepository.GetRamById(ramId);
            if(ram==null)
            {
                return Result.Error(ErrorType.NotFound);
            }
            ram.Size = ramUpdateDto.Size ?? ram.Size;
            await _uow.RamRepository.UpdateRam(ram);
            await _uow.SaveAsync(token);
            return Result.Ok("Successfully Updated");
        }
    }
}
