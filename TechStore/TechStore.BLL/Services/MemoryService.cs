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
using TechStore.BLL.DtoModels.Memory;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class MemoryService : IMemoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public MemoryService(IUnitOfWork uow, IMapper mapper, IServiceProvider serviceProvider)
        {
            _uow = uow;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }
        public async Task<Result> AddMemory(MemoryAddDto memoryAddDto, CancellationToken token = default)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<MemoryAddDto>>();
            var validationResult = await validator.ValidateAsync(memoryAddDto, token);
            if (!validationResult.IsValid)
                return Result.ValidationError(validationResult.Errors);

            var memory = _mapper.Map<Memory>(memoryAddDto);
            await _uow.MemoryRepository.AddMemory(memory, token);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully created.");
        }

        public async Task<Result> DeleteMemory(int memoryId, CancellationToken token = default)
        {
            var memory = await _uow.MemoryRepository.GetMemoryById(memoryId, token);

            if (memory == null)
                return Result.Error(ErrorType.NotFound);

            await _uow.MemoryRepository.DeleteMemory(memory);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully deleted.");
        }

        public async Task<IEnumerable<MemoryDto>> GetMemories(CancellationToken token = default)
        {
            return _mapper.Map<List<MemoryDto>>(await _uow.MemoryRepository.GetMemories(token));
        }

        public async Task<IEnumerable<MemoryDto>> GetMemoriesByCategoryId(int categoryId, CancellationToken token = default)
        {
            var memories = await _uow.MemoryRepository.GetMemoriesByCategoryId(categoryId, token);
            return _mapper.Map<List<MemoryDto>>(memories);
        }

        public async Task<MemoryDto?> GetMemoryById(int memoryId, CancellationToken token = default)
        {
            return _mapper.Map<MemoryDto>(await _uow.MemoryRepository.GetMemoryById(memoryId, token));

        }

        public async Task<Result> UpdateMemory(int memoryId, MemoryUpdateDto memoryUpdateDto, CancellationToken token = default)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<MemoryUpdateDto>>();
            var validationResult = await validator.ValidateAsync(memoryUpdateDto, token);
            if (!validationResult.IsValid)
                return Result.ValidationError(validationResult.Errors);

            var memory = await _uow.MemoryRepository.GetMemoryById(memoryId, token);

            if (memory == null)
                return Result.Error(ErrorType.NotFound);

            memory.Size = memoryUpdateDto.Size ?? memory.Size;

            await _uow.MemoryRepository.UpdateMemory(memory);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully updated.");
        }
    }
}
