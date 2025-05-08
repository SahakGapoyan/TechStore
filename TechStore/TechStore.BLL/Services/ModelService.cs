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
using TechStore.BLL.DtoModels.Model;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public ModelService(IUnitOfWork uow, IMapper mapper, IServiceProvider serviceProvider)
        {
            _uow = uow;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }
        public async Task<Result> AddModel(ModelAddDto modelAddDto, CancellationToken token = default)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<ModelAddDto>>();
            var validationResult = await validator.ValidateAsync(modelAddDto, token);
            if (!validationResult.IsValid)
                return Result.ValidationError(validationResult.Errors);

            var model = _mapper.Map<Model>(modelAddDto);
            await _uow.ModelRepository.AddModel(model, token);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully created.");
        }

        public async Task<Result> Delete(int modelId, CancellationToken token = default)
        {
            var model = await _uow.ModelRepository.GetModel(modelId, token);

            if (model == null)
                return Result.Error(ErrorType.NotFound);

            await _uow.ModelRepository.Delete(model);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully deleted");
        }

        public async Task<ModelDto?> GetModel(int modelId, CancellationToken token = default)
        {
            return _mapper.Map<ModelDto>(await _uow.ModelRepository.GetModel(modelId, token));
        }

        public async Task<IEnumerable<ModelDto>> GetModels(CancellationToken token = default)
        {
            return _mapper.Map<List<ModelDto>>(await _uow.ModelRepository.GetModels(token));
        }

        public async Task<IEnumerable<ModelDto>> GetModelsByCategoryId(int categoryId, CancellationToken token = default)
        {
            var models = await _uow.ModelRepository.GetModelsByCategoryId(categoryId, token);
            return _mapper.Map<List<ModelDto>>(models);
        }

        public async Task<Result> UpdateModel(int modelId, ModelUpdateDto modelUpdateDto, CancellationToken token = default)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<ModelUpdateDto>>();
            var validationResult = await validator.ValidateAsync(modelUpdateDto, token);
            if (!validationResult.IsValid)
                return Result.ValidationError(validationResult.Errors);

            var model = await _uow.ModelRepository.GetModel(modelId, token);

            if (model == null)
                return Result.Error(ErrorType.NotFound);

            model.Name = modelUpdateDto.Name ?? model.Name;
            model.Stock = modelUpdateDto.Stock ?? model.Stock;
            model.AnnouncementYear = modelUpdateDto.AnnouncementYear ?? model.AnnouncementYear;

            await _uow.ModelRepository.Update(model);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully updated.");
        }
    }
}
