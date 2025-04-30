using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Color;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ColorService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddColor(ColorAddDto colorAddDto, CancellationToken token = default)
        {
            var color = _mapper.Map<Color>(colorAddDto);
            await _uow.ColorRepository.AddColor(color,token);
            await _uow.SaveAsync(token);
        }

        public async Task<Result> DeleteColor(int colorId, CancellationToken token = default)
        {
            var color = await _uow.ColorRepository.GetColorById(colorId, token);
            if(color==null)
            {
                return Result.Error(ErrorType.NotFound);
            }
            await _uow.ColorRepository.DeleteColor(color);
            await _uow.SaveAsync(token);
            return Result.Ok("Successfully deleted");
        }

        public async Task<ColorDto?> GetColorById(int colorId, CancellationToken token = default)
        {
            return _mapper.Map<ColorDto>(await _uow.ColorRepository.GetColorById(colorId));
        }

        public async Task<IEnumerable<ColorDto>> GetColors(CancellationToken token)
        {
            return _mapper.Map<List<ColorDto>>(await _uow.ColorRepository.GetColors(token));
        }

        public async Task<IEnumerable<ColorDto>> GetColorsByCategoryId(int categoryId, CancellationToken token = default)
        {
            var colors = await _uow.ColorRepository.GetColorssByCategoryId(categoryId, token);
            return _mapper.Map<List<ColorDto>>(colors);
        }

        public async Task<Result> UpdateColor(int colorId, ColorUpdateDto colorUpdateDto, CancellationToken token = default)
        {
            var color = await _uow.ColorRepository.GetColorById(colorId, token);
            if (color == null)
            {
                return Result.Error(ErrorType.NotFound);
            }
            color.Name = colorUpdateDto.Name ?? color.Name;
            color.HexCode=colorUpdateDto.HexCode ?? color.HexCode;
            await _uow.ColorRepository.UpdateColor(color);
            await _uow.SaveAsync(token);
            return Result.Ok("Successfully Updated");
        }
    }
}
