﻿using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.OS;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class OSService : IOSService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public OSService(IUnitOfWork uow, IMapper mapper, IServiceProvider serviceProvider)
        {
            _uow = uow;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }
        public async Task<Result> AddOS(OSAddDto oSAddDto, CancellationToken token = default)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<OSAddDto>>();
            var validationResult = await validator.ValidateAsync(oSAddDto, token);
            if (!validationResult.IsValid)
                return Result.ValidationError(validationResult.Errors);

            var os = _mapper.Map<OS>(oSAddDto);
            await _uow.OSRepsoitory.AddOS(os, token);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully created.");

        }

        public async Task<Result> DeleteOS(int OsId, CancellationToken token)
        {
            var os = await _uow.OSRepsoitory.GetOSById(OsId, token);

            if (os == null)
                return Result.Error(ErrorType.NotFound);

            await _uow.OSRepsoitory.DeleteOS(os);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully deleted.");
        }

        public async Task<OSDto?> GetOSById(int osId, CancellationToken token = default)
        {
            return _mapper.Map<OSDto>(await _uow.OSRepsoitory.GetOSById(osId, token));
        }

        public async Task<IEnumerable<OSDto>> GetOsesByCategoryId(int categoryId, CancellationToken token = default)
        {
            var oses = await _uow.OSRepsoitory.GetOsesByCategoryId(categoryId, token);
            return _mapper.Map<List<OSDto>>(oses);
        }

        public async Task<IEnumerable<OSDto>> GetOSs(CancellationToken token = default)
        {
            var oSs = await _uow.OSRepsoitory.GetOSs(token);
            return _mapper.Map<List<OSDto>>(oSs);
        }

        public async Task<Result> UpdateOS(int OsId, OSUpdateDto oSUpdateDto, CancellationToken token)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<OSUpdateDto>>();
            var validationResult = await validator.ValidateAsync(oSUpdateDto, token);
            if (!validationResult.IsValid)
                return Result.ValidationError(validationResult.Errors);

            var os = await _uow.OSRepsoitory.GetOSById(OsId, token);

            if (os == null)
                return Result.Error(ErrorType.NotFound);

            os.Name = oSUpdateDto.Name ?? os.Name;

            await _uow.OSRepsoitory.UpdateOS(os);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully updated.");
        }
    }
}
