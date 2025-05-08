using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Category;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Ram;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public CategoryService(IUnitOfWork uow, IMapper mapper, IServiceProvider serviceProvider)
        {
            _uow = uow;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }
        public async Task<Result> AddCategory(CategoryAddDto categoryAddDto, CancellationToken token = default)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<CategoryAddDto>>();
            var validationResult = await validator.ValidateAsync(categoryAddDto, token);
            if (!validationResult.IsValid)
                return Result.ValidationError(validationResult.Errors);

            var category = _mapper.Map<Category>(categoryAddDto);
            await _uow.CategoryRepository.AddCategory(category, token);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully created.");
        }

        public async Task<Result> DeleteCategory(int categoryId, CancellationToken token = default)
        {
            var category = await _uow.CategoryRepository.GetCategory(categoryId);
            if (category == null)
            {
                return Result.Error(ErrorType.NotFound);
            }
            await _uow.CategoryRepository.DeleteCategory(category);
            await _uow.SaveAsync(token);
            return Result.Ok("Successfully Deleted");
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories(CancellationToken token = default)
        {
            var categories = await _uow.CategoryRepository.GetCategories(token);
            return _mapper.Map<List<CategoryDto>>(categories);

        }

        public async Task<CategoryDto?> GetCategory(int id, CancellationToken token = default)
        {
            var category = await _uow.CategoryRepository.GetCategory(id, token);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<Result> UpdateCategory(int categoryId, CategoryUpdateDto categoryUpdateDto, CancellationToken token = default)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<CategoryUpdateDto>>();
            var validationResult = await validator.ValidateAsync(categoryUpdateDto, token);
            if (!validationResult.IsValid)
                return Result.ValidationError(validationResult.Errors);

            var category = await _uow.CategoryRepository.GetCategory(categoryId, token);
            if (category == null)
            {
                return Result.Error(ErrorType.NotFound);
            }

            category.Name = categoryUpdateDto.Name ?? category.Name;
            category.Description = categoryUpdateDto.Description ?? category.Description;
            await _uow.CategoryRepository.UpdateCategory(category);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully updated");
        }
    }
}
